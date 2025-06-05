from abc import abstractmethod, ABC
from typing import final, Final


class Hero(ABC):
    def __init__(self, name: str, hp: int, max_attack: int) -> None:
        self.MAX_HP: Final = 500
        self.name = name
        self.hp = hp
        self.max_attack = max_attack
        self.__alive = True

    @final
    @property
    def name(self) -> str:
        return self.__name

    @final
    @name.setter
    def name(self, name: str) -> None:
        if not name:
            raise ValueError("Name can`t be empty!")
        self.__name = name

    @final
    @name.deleter
    def name(self) -> None:
        del self.__name

    @final
    @property
    def hp(self) -> int:
        return self.__hp

    @final
    @hp.setter
    def hp(self, hp: int) -> None:
        self.__hp = max(min(hp, self.MAX_HP), 0)
        if self.__hp <= 0:
            self.__alive = False

    @final
    @property
    def max_attack(self) -> int:
        return self.__max_attack

    @final
    @max_attack.setter
    def max_attack(self, max_attack: int) -> None:
        self.__max_attack = max(max_attack, 0)

    @final
    @property
    def is_alive(self) -> bool:
        return self.__alive

    def __eq__(self, other):
        if not isinstance(other, Hero):
            return False
        return (self.name == other.name
                and self.hp == other.hp
                and self.max_attack == other.max_attack
                and self.is_alive
                and other.is_alive)

    def __hash__(self) -> int:
        return hash((self.name, self.hp, self.max_attack, self.is_alive))

    def __repr__(self) -> str:
        return f"Hero(name=={self.name!r}, hp={self.hp}, max_attack={self.max_attack}, is_alive={self.is_alive})"

    def __str__(self) -> str:
        return f"{self.name}, hp:{self}, alive:{'Alive' if self.is_alive else 'Dead'}"

    def take_damage(self, damage: int) -> None:
        self.hp -= max(damage, 0)

    def make_attack(self, damage: int) -> None:
        if self.is_alive:
            return randint(0, self.max_attack)
        return 0

    # @abstractmethod
    # def test(self):
    #     pass
