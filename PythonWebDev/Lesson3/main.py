class Product:
    __counter = 0

    def __init__(self, name, price, category, in_stock, supplier, rating):
        Product.__counter += 1
        self.__id = Product.__counter  # унікальний ідентифікатор
        self.__name = name
        self.__price = price
        self.__category = category
        self.__in_stock = in_stock
        self.__supplier = supplier
        self.__rating = rating

    @staticmethod
    def get_counter():
        return Product.__counter

    def get_id(self):
        return self.__id

    def get_name(self):
        return self.__name

    def set_name(self, name):
        self.__name = name

    def get_price(self):
        return self.__price

    def set_price(self, price):
        self.__price = price

    def get_category(self):
        return self.__category

    def set_category(self, category):
        self.__category = category

    def is_in_stock(self):
        return self.__in_stock

    def set_in_stock(self, in_stock):
        self.__in_stock = in_stock

    def get_supplier(self):
        return self.__supplier

    def set_supplier(self, supplier):
        self.__supplier = supplier

    def get_rating(self):
        return self.__rating

    def set_rating(self, rating):
        self.__rating = rating

    def __str__(self):
        in_stock_str = "так" if self.__in_stock else "ні"
        return f'Product "{self.__name}" (category: {self.__category}) - ₴{self.__price}, in stock: {in_stock_str}'

    def __repr__(self):
        return (f'id: {self.__id}, name: {self.__name}, price: {self.__price}, '
                f'category: {self.__category}, supplier: {self.__supplier}, rating: {self.__rating}')

    def __eq__(self, other):
        if not isinstance(other, Product):
            return False
        return (self.__id == other.__id and
                self.__name == other.__name and
                self.__price == other.__price and
                self.__category == other.__category)

    # Хешування
    def __hash__(self):
        return hash(self.__id)


p1 = Product("Laptop", 25000, "electronics", True, "TechStore", 4.8)
p2 = Product("Bread", 45, "food", True, "Bakery", 4.5)
p3 = Product("Laptop", 25000, "electronics", True, "TechStore", 4.8)

print(p1)
print(p2)
print(p3)
print(repr(p1))
print(repr(p2))
print(repr(p3))

print("p1 == p3:", p1 == p3)
print("p1 == p2:", p1 == p2)

print("Total products:", Product.get_counter())

p1.set_rating(5.0)
p2.set_in_stock(False)
print(p1)
print(p2)
