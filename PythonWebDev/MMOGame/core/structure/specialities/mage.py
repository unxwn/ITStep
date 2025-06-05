from core.structure.base.hero import Hero
from abc import ABC
from random import randint
from typing import final

class Mage(Hero, ABC):
    def __init__(self, name: str, hp: int, max_attack: int, mana: int) -> None:
        super().__init__(name, hp, max_attack)
        self.mana = mana

    @final
    @property
    def mana(self) -> int:
        return self.__mana

    @final
    @mana.setter
    def mana(self, mana: int) -> None:
        self.__mana = max(mana, 0)

    def __eq__(self, other) -> bool:
        if not isinstance(other, Mage):
            return False
        return super().__eq__(other) and self.mana == other.mana

    def __hash__(self) -> int:
        return hash((super().__hash__(), self.mana))

    def __repr__(self) -> str:
        return (f"{self.__class__.__name__}("
                f"name={self.name!r}, "
                f"hp={self.hp}, "
                f"max_attack={self.max_attack}, "
                f"is_alive={self.is_alive}, "
                f"mana={self.mana}"
                f")")

    def __str__(self) -> str:
        return f"{super().__str__()}, mana:{self.mana}"

    def make_attack(self) -> int:
        if self.is_alive and self.mana >= 10:
            boost = randint(1, 10)
            self.mana -= 10
            return super().make_attack() + boost
        return super().make_attack()

    def heal(self) -> None:
        if self.is_alive and self.mana >= 20:
            self.hp += 30
            self.mana -= 20
