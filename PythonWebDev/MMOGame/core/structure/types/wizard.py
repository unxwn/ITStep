from core.structure.specialities.mage import Mage
from typing import final

@final
class Wizard(Mage):
    def __init__(self, name: str, hp: int, max_attack: int, mana: int):
        super().__init__(name, hp, max_attack, int(mana * 1.5))

    def __str__(self):
        return f"Wizard, {super().__str__()}"
