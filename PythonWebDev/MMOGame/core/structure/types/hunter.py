from core.structure.specialities.archer import Archer
from typing import final

@final
class Hunter(Archer):
    def __init__(self, name: str, hp: int, max_attack: int, charges: int):
        super().__init__(name, hp, max_attack, charges)

    def __str__(self):
        return f"Hunter, {super().__str__()}"
