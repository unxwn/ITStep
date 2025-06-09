from dataclasses import dataclass, field
import uuid

@dataclass
class Book:
    __title: str
    __author: str
    __year: int
    __available: bool = True

    __rating: float = field(default=0.0, init=False, repr=False)
    __tags: list[str] = field(default_factory=list)
    __internal_code: str = field(init=False, repr=False)

    def __post_init__(self):
        prefix = self.__title[:3].upper()
        suffix = uuid.uuid4().hex[:6]
        self.__internal_code = f"{prefix}-{self.__year}-{suffix}"

    @property
    def title(self) -> str:
        return self.__title

    @property
    def author(self) -> str:
        return self.__author

    @property
    def year(self) -> int:
        return self.__year

    @property
    def available(self) -> bool:
        return self.__available

    @available.setter
    def available(self, value: bool):
        self.__available = value

    @property
    def rating(self) -> float:
        return self.__rating

    def update_rating(self, new_rating: float):
        if not (0.0 <= new_rating <= 5.0):
            raise ValueError("rating must be between 0.0 and 5.0")
        self.__rating = new_rating

    @property
    def tags(self) -> list[str]:
        return list(self.__tags)

    def add_tag(self, tag: str):
        if tag not in self.__tags:
            self.__tags.append(tag)

    @property
    def internal_code(self) -> str:
        return self.__internal_code


# Перевірка
book1 = Book(
    "The Hobbit",
    "J.R.R. Tolkien",
    1937,
    True,
    ["fantasy", "adventure", "classic"]
)
print(book1.title)
print(book1.author)
print(book1.year)
print(book1.available)
print(book1.rating)
print(book1.tags)
print(book1.internal_code)
