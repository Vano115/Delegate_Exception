using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_Exception.Properties
{
    /// <summary>
    /// Событие-выбор метода сортировки
    /// </summary>
    class EventChoice
    {
        public delegate void EventChoiceDelegate(int number, List<string> list);  // Создание делегата для события
        public event EventChoiceDelegate ChoiceEvent;  // Создание события

        /// <summary>
        /// Метод выбора способа сортировки
        /// </summary>
        /// <param name="list">Сортируемый список</param>
        /// <exception cref="FormatException">Исключение при вводе не целочисленного значения</exception>
        /// <exception cref="NonNeedNumberException">Исключение при вводе не 1 или 2</exception>
        public void CheckNum(List<string> list)
        {
            Console.WriteLine("\nСортировка списка фамилий, введите значение" +
                "\n1 - сортировка от А до Я\n2 - сортировка от Я до А");
            
            int number = 0;
            if (Int32.TryParse(Console.ReadLine(), out number) == false)
            {
                throw new FormatException();
            }
            if (number != 1 && number != 2)
            {
                throw new NonNeedNumberException();
            }

            OnChoiceEvent(number, list);
        }

        /// <summary>
        /// Вызов события
        /// </summary>
        /// <param name="number">Обозначение способа сортировки</param>
        /// <param name="list">Сортируемый список</param>
        protected virtual void OnChoiceEvent(int number, List<string> list)
        {
            ChoiceEvent?.Invoke(number, list);
        }
    }
}
