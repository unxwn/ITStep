from core.structure.specialities.warrior import Warrior
from typing import final

@final
class Paladin(Warrior):
    def __init__(self, name: str, hp: int, max_attack: int, armor: int):
        super().__init__(name, hp, max_attack, int(armor * 1.7))

    def __str__(self):
        return f"Paladin, {super().__str__()}"
