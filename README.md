# Basketball VR
<img width="2278" height="1233" alt="зображення" src="https://github.com/user-attachments/assets/0beccffc-e4c6-4357-b7ee-256edcfeb9fd" />

* Технічне завдання [ось тут](/tz.md)
* Білд можна скачати [звідси](https://github.com/andriihorlov/BasketballVR/releases)

## Використано
- Unity 6000.2.6f2
- XR Interaction Toolkit (ver. 3.2.1)
- Open XR (ver. 1.15.1)
- [Service Locator](https://assetstore.unity.com/packages/tools/utilities/servicelocator-273013) (написаний колись мною)
- 3д асети та текстури з різних ресурсів (free3d, cgtrader, google image, тощо)


## Структура проєкту
<img width="265" height="428" alt="зображення" src="https://github.com/user-attachments/assets/d1c7d4fd-2b9f-4de4-95c6-f8e081b37c90" />

Все, що стосується проєкту в директорії - **BasketballVR**.

Скрипти розбиті на модулі: **Game** та **UI**. Вони лежать разом з **Content** та **Data** в корні папки **BasketballVR**.

* **Content** - має в собі файли, які не є скриптами (Префаби, 3д Ассети, сцени, спрайти, тощо)
* **Data** - має в собі скріптабл обджекти які містять дані, які необхідні для роботи з додатком. (В даному випадку різні налаштування м'ячів)
* **Game** - все що стосується гри.
* **UI** - все що стосується UI.
* **Global Controller** - головний контролер який задає налаштування, та веде комунікацію між двома модулями. Також відповідає за запуск партиклів при закиданні м'яча в корзину. 
(*Можливо краще було б вивести партікли в окремий модуль, але оскільки там лише один ефект, то залишив його поки що тут*)

## Нотатка

В гіті головна бренча це **main**. Проте, як я писав в LinkedIn, я залишив [**app-setup**](https://github.com/andriihorlov/BasketballVR/tree/app-setup), для зручності твоєї перевірки (в разі якщо воно тобі треба).

<img width="1481" height="1073" alt="зображення" src="https://github.com/user-attachments/assets/c51e3019-7f6f-4201-bd21-e395ee28d6d4" />
