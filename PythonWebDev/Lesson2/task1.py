# 1. Створення словника студентів
students = {
    "ivanov@gmail.com": {
        "name": "Іванов Іван",
        "age": 20,
        "subjects": {"математика": 85, "фізика": 90}
    },
    "petrenko@gmail.com": {
        "name": "Петренко Олена",
        "age": 22,
        "subjects": {"математика": 78}
    }
}

# 2. Додаємо нового студента
students["shevchenko@gmail.com"] = {
    "name": "Шевченко Тарас",
    "age": 21,
    "subjects": {"історія": 92, "література": 89}
}

# 3. Додаємо студенту новий предмет
students["ivanov@gmail.com"]["subjects"]["інформатика"] = 95

# 4. Видаляємо предмет у студента
del students["petrenko@gmail.com"]["subjects"]["математика"]

# 5. Обчислення середнього балу кожного студента
for email, info in students.items():
    subjects = info["subjects"]
    if subjects:
        avg = sum(subjects.values()) / len(subjects)
        print(f"{info['name']}: {avg:.1f}")
    else:
        print(f"{info['name']}: немає предметів")

# 6. Студент з найкращим середнім балом
best_student = None
best_avg = -1
for info in students.values():
    subjects = info["subjects"]
    if subjects:
        avg = sum(subjects.values()) / len(subjects)
        if avg > best_avg:
            best_avg = avg
            best_student = info["name"]
print(f"Найкращий студент: {best_student} — {best_avg:.1f}")
