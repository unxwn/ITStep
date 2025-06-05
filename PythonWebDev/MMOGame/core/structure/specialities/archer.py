from core.structure.base.hero import Hero
from abc import ABC
from random import randint
from typing import final

class Archer(Hero, ABC):
    def __init__(self, name: str, hp: int, max_attack: int, charges: int) -> None:
        super().__init__(name, hp, max_attack)
        self.charges = charges

    @final
    @property
    def charges(self) -> int:
        return self.__charges

    @final
    @charges.setter
    def charges(self, charges: int) -> None:
        self.__charges = max(charges, 0)

    def __eq__(self, other) -> bool:
        if not isinstance(other, Archer):
            return False
        return super().__eq__(other) and self.charges == other.charges

    def __hash__(self) -> int:
        return hash((super().__hash__(), self.charges))

    def __repr__(self) -> str:
        return (f"{self.__class__.__name__}("
                f"name={self.name!r}, "
                f"hp={self.hp}, "
                f"max_attack={self.max_attack}, "
                f"is_alive={self.is_alive}, "
                f"charges={self.charges}"
                f")")

    def __str__(self) -> str:
        return f"{super().__str__()}, charges:{self.charges}"

    def make_attack(self) -> int:
        if self.is_alive and self.charges > 0:
            self.charges -= 1
            return super().make_attack()
        return 0
