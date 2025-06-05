from core.structure.specialities.warrior import Warrior
from typing import final

@final
class Berserk(Warrior):
    def __init__(self, name: str, hp: int, max_attack: int, armor: int):
        super().__init__(name, hp, max_attack, int(armor * 0.6))

    def __str__(self):
        return f"Berserk, {super().__str__()}"
