from core.structure.specialities.mage import Mage
from typing import final

@final
class Warlock(Mage):
    def __init__(self, name: str, hp: int, max_attack: int, mana: int):
        super().__init__(name, hp, max_attack, int(mana * 1.2))

    def __str__(self):
        return f"Warlock, {super().__str__()}"
