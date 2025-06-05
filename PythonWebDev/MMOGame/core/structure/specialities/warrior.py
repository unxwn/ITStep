from core.structure.base.hero import Hero

from abc import ABC
from typing import final

class Warrior(Hero, ABC):
    print(super().name)
    def __init__(self, name: str, hp: int, max_attack: int, armor: int) -> None:
        super().__init__(name, hp, max_attack)
        self.armor = armor

        @final
        @property
        def armor(self) -> int:
            return self.__armor

        @final
        @armor.setter
        def armor(self, armor: int) -> None:
            self.__armor = max(armor, 0)

        def __eq__(self, other: object) -> bool:
            if not isinstance(other, Warrior): return False
            return super().__eq__(other) and self.armor == other.armor

        def __hash__(self) -> int:
            return hash(super().__hash__(), self.armor)

        def __repr__(self) -> str:
            return (f"{self.__class__.__name__}("
                    f"name={self.name!r}, "
                    f"hp={self.hp}, "
                    f"max_attack={self.max_attack}, "
                    f"is_alive={self.is_alive}, "
                    f"armor)"
                    f")")

        def __str__(self) -> str:
            return f"{super().__str__()}, armor:{self.armor})"

        def take_damage(self, damage: int) -> None:
            super().take_damage(damage - self.armor)
            self.armor = self.armor - damage
