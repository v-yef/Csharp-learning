/*
 ============================================================================
 Name        : Homework_7-Task_1
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : Write a program to display user-specified geometric shapes in the
               console. The user selects a shape's type, position, size and color
               using a menu. All user-defined shapes must be displayed on the
               screen simultaneously. Shapes (rectangle, rhombus, triangle,
               polygon) are drawn with asterisks or other symbols. To write the
               program, it is necessary to build a class hierarchy (consider the
               possibility of abstraction). To store user-defined shapes create
               a “Collection of geometric shapes” class with the “Display all
               shapes” method. To display all shapes using the specified method,
               you need to use the foreach operator, for which you must implement
               the appropriate interfaces.
 ============================================================================
 */

namespace Task_1
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            var collection = new ShapeCollection();
            collection.MenuStart();
        }
    }
}
