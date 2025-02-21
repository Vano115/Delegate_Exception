using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_Exception.Properties
{
    class EventChoice
    {
        public delegate void EventChoiceDelegate(int number, List<string> list);  // Создание делегата для события
        public event EventChoiceDelegate ChoiceEvent;  // Создание события

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
        // Метод для задачи способа сортировки

        protected virtual void OnChoiceEvent(int number, List<string> list)
        {
            ChoiceEvent?.Invoke(number, list);
        }
    }
}
