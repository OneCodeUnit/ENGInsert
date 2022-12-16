Программа для создания комментариев с исходным тестом для .xml-файлов локализации.

## Использование
Поместить исполняемый файл в корень папки переводимого мода (уже обработанного RimTrans или его аналогом) и запустить. Программа обработает все .xml файлы в текущей папке и во всех вложенных подпапках.

## Пример
Исходный текст:
> \<VBE_InsertSyrupDesc>Syrup to Insert</VBE_InsertSyrupDesc>\
> \<VBE_StartInsertion>Bring Syrup</VBE_StartInsertion>\
> \<VBE_StartInsertionDesc>Bring a syrup to the soda fountain to start processing</VBE_StartInsertionDesc>\
> \<VBE_CancelBringingSyrup>Cancel Bringing Syrup</VBE_CancelBringingSyrup>\
> \<VBE_CancelBringingSyrupDesc>Cancel bringing syrup to the soda fountain.</VBE_CancelBringingSyrupDesc>

Обработанный текст:
> \<!-- EN: Syrup to Insert -->\
> \<VBE_InsertSyrupDesc>Syrup to Insert</VBE_InsertSyrupDesc>\
> \<!-- EN: Bring Syrup -->\
> \<VBE_StartInsertion>Bring Syrup</VBE_StartInsertion>\
> \<!-- EN: Bring a syrup to the soda fountain to start processing -->\
> \<VBE_StartInsertionDesc>Bring a syrup to the soda fountain to start processing</VBE_StartInsertionDesc>\
> \<!-- EN: Cancel Bringing Syrup -->\
> \<VBE_CancelBringingSyrup>Cancel Bringing Syrup</VBE_CancelBringingSyrup>\
> \<!-- EN: Cancel bringing syrup to the soda fountain. -->\
> \<VBE_CancelBringingSyrupDesc>Cancel bringing syrup to the soda fountain.</VBE_CancelBringingSyrupDesc>

## Версии для других платформ
Программа написана на кроссплатформенном .Net 7, поэтому должна работать на любой платформе. Однако я могу протестировать только версию для Windows. Обязательно сообщайте об ошибках для других платформ.
