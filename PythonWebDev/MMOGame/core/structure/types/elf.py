from core.structure.specialities.archer import Archer
from typing import final

@final
class Elf(Archer):
    def __init__(self, name: str, hp: int, max_attack: int, charges: int):
        super().__init__(name, hp, max_attack, charges + 3)

    def __str__(self):
        return f"Elf, {super().__str__()}"
