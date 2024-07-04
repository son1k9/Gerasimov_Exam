using System;

namespace src
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 1;

            bool sizeInputError = true;
            while (sizeInputError)
            {
                sizeInputError = false;
                Console.Write("Введите размер массива: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int value))
                {
                    if (value < 1)
                    {
                        sizeInputError = true;
                        Console.WriteLine("Минимальный размер массива - 1");
                    }
                    else
                    {
                        size = value;
                    }
                }
                else
                {
                    sizeInputError = true;
                    Console.WriteLine("Размер массива должен быть положительным целым числом");
                }
            }

            PlanControl array = new PlanControl(size);

            Console.WriteLine("Заполните массив:");
            for(int i = 0; i < array.Array.Length; i++)
            {
                Subject subj = new Subject();
                Console.WriteLine($"[{i}]");

                bool inputError = true;
                string input;
                while (inputError)
                {
                    inputError = false;

                    Console.Write("Семестр: ");
                    input = Console.ReadLine();
                    if (int.TryParse(input, out int value))
                    {
                        if (value < 1)
                        {
                            inputError = true;
                        }
                        else
                        {
                            subj.Semester = value;
                        }
                    }
                    else
                    {
                        inputError = true;
                    }
                    if (inputError)
                    {
                        Console.WriteLine("Некоректный семестр.");
                    }
                }

                inputError = true;
                while (inputError)
                {
                    inputError = false;

                    Console.Write("Название: ");
                    input = Console.ReadLine();
                    if (string.IsNullOrEmpty(input))
                    {
                        inputError = true;
                    }
                    else
                    {
                        subj.Name = input;
                    }
                    if (inputError)
                    {
                        Console.WriteLine("Некоректое название.");
                    }
                }

                inputError = true;
                while (inputError)
                {
                    inputError = false; 

                    Console.Write("Фамилия преподавателя: ");
                    input = Console.ReadLine();
                    if (string.IsNullOrEmpty(input))
                    {
                        inputError = true;
                    }
                    else
                    {
                        subj.LectorLastname = input;
                    }
                    if (inputError)
                    {
                        Console.WriteLine("Некоректая фамилия.");
                    }
                }

                array.Array[i] = subj;
            }

            array.Sort();

            Console.Write("Укажите путь к файлу:");
            string inputFilename = Console.ReadLine();

            bool saveError = true;

            while (saveError)
            {
                saveError = false;
                try
                {
                    array.SaveToFile(inputFilename);
                }
                catch
                {
                    saveError = true;
                }
            }

            Console.WriteLine("Создан файл в указанной директории.");
            Console.WriteLine("Нажмите любую клавишу для завершения программы");
            Console.ReadLine();
        }
    }
}
