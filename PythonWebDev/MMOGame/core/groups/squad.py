from core.structure.types_enum import Types
from core.structure.types.paladin import Paladin
from core.structure.types.berserk import Berserk
from core.structure.types.wizard import Wizard
from core.structure.types.warlock import Warlock
from core.structure.types.elf import Elf
from core.structure.types.hunter import Hunter
from core.structure.base.hero import Hero
from random import choice, randint


def generate_name() -> str:
    return choice(["Arthas", "Sylvanas", "Thrall", "Jaina", "Illidan", "Varian"])

class Squad:
    def __init__(self, size: int):
        self.__size = max(size, 1)
        self.__heroes = []
        self.__fill()

    def __fill(self):
        for _ in range(self.__size):
            match choice(tuple(Types)):
                case Types.PALADIN:
                    hero = Paladin(generate_name(), randint(100, 200), randint(30, 70), 40)
                case Types.BERSERK:
                    hero = Berserk(generate_name(), randint(100, 200), randint(30, 70), 30)
                case Types.WIZARD:
                    hero = Wizard(generate_name(), randint(100, 200), randint(30, 70), 50)
                case Types.WARLOCK:
                    hero = Warlock(generate_name(), randint(100, 200), randint(30, 70), 60)
                case Types.ELF:
                    hero = Elf(generate_name(), randint(100, 200), randint(30, 70), 7)
                case Types.HUNTER:
                    hero = Hunter(generate_name(), randint(100, 200), randint(30, 70), 10)
                case _:
                    raise ValueError("Wrong value")
            self.__heroes.append(hero)

    def __str__(self):
        return "\n".join(str(hero) for hero in self.__heroes)

    def any_alive(self) -> bool:
        return any(hero.is_alive for hero in self.__heroes)

    def get_hero(self) -> Hero:
        alive_heroes = [hero for hero in self.__heroes if hero.is_alive]
        if not alive_heroes:
            raise ValueError("No any alive")
        return choice(alive_heroes)
