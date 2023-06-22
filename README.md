# tz_mindbox
<p>
Библиотека Figure описана в файле <a href="https://github.com/JulLazz/tz_mindbox/blob/master/tz_mindbox/Figure.cs">Figure.cs</a>. Для добавления новой фигуры необходимо создать новый класс, реализующий интерфейс IFigure, конструктор которого, в качестве параметра, принимает массив типа double. 
Для треугольника так же есть метод на проверку его прямоугольности.
</p>
<p>
  В папке <a href="https://github.com/JulLazz/tz_mindbox/tree/master/FigureUnitTest">FigureUnitTest</a> хранятся файлы с юнит-тестами для основного функционала созданных классов, реализующих интерфейс IFigure.
</p>
<p>
  <a href="https://github.com/JulLazz/tz_mindbox/blob/master/UsingLib/Program.cs">Пример использования библиотеки</a> демонстрирует вычисление площади фигуры, тип который неизвестен на этапе компиляции. При добавлении новго класса, реализующего интерфейс IFigure его название появится в списке выбора типов фигур, а для полноценной работы с этим классом необходимо будет добавить пункт в swich.
</p>
<p>
  Для получения площади фигуры, тип которой определяется пользователем в run-time был создан статический класс <a href="https://github.com/JulLazz/tz_mindbox/blob/master/tz_mindbox/Figure.cs">SquareFinder</a>, который создает обект заданного пользователем типа и возвращает его площадь.
</p>
<p>
  <a href="https://github.com/JulLazz/tz_mindbox/blob/master/sql_products%26category.sql">Скрипт для задания 2</a> содержит в себе создание таблиц, их заполнение и запрос для выбора всех пар «Имя продукта – Имя категории»
</p>
