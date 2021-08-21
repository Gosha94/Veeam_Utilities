using System;
using OpenQA.Selenium;
using VacancyFinder.Contracts;
using System.Collections.ObjectModel;

namespace VacancyFinder.Service
{
    /// <summary>
    /// Служба нажатия на элементы веб-интерфейса
    /// </summary>
    public sealed class ClickerService : IService
    {
        /// <summary>
        /// Метод нажатия на отдельный элемент веб-интерфейса
        /// </summary>
        /// <param name="element"></param>
        public void ClickOnSingleElement(IWebElement element) => element.Click();

        /// <summary>
        /// Метод нажатия на элемент выпадающего списка
        /// </summary>
        /// <param name="dropDownList">Выпадающий список</param>
        /// <param name="expectedString">Наименование элемента, который необходимо выбрать</param>
        public void ClickOnElementInDropDownList(ReadOnlyCollection<IWebElement> dropDownList, string expectedString)
        {
            var comparer = StringComparer.OrdinalIgnoreCase;

            foreach (var item in dropDownList)
            {
                if (comparer.Compare(item.Text, expectedString) == 0)  // 0 - Both strings are equal in value
                {
                    item.Click();
                    return;
                }
            }
        }
    }
}
