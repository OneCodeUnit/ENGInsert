Программа для создания комментариев с исходным тестом для .xml-файлов локализации.

## Использование
Поместить исполняемый файл (или его ярлык) в корень папки переводимого мода и запустить. Программа обработает все .xml файлы в текущей папке и во всех вложенных подпапках.

## Пример
Исходный текст:
> \<VBE_InsertSyrupDesc>Syrup to Insert</VBE_InsertSyrupDesc>\
> \<VBE_StartInsertion>Bring Syrup</VBE_StartInsertion>\
> \<VBE_StartInsertionDesc>Bring a syrup to the soda fountain to start processing</VBE_StartInsertionDesc>\
> \<VBE_CancelBringingSyrup>Cancel Bringing Syrup</VBE_CancelBringingSyrup>\
> \<VBE_CancelBringingSyrupDesc>Cancel bringing syrup to the soda fountain.</VBE_CancelBringingSyrupDesc>\
> \<VBE_SyrupFailurePower>The soda has spoiled due to a power failure in the soda fountain</VBE_SyrupFailurePower>

Обработанный текст:
> \<!-- EN: Syrup to Insert -->\
> \<VBE_StartInsertion>Syrup to Insert</VBE_StartInsertion>\
> \<!-- EN: Bring Syrup -->\
> \<VBE_StartInsertionDesc>Bring Syrup</VBE_StartInsertionDesc>\
> \<!-- EN: Bring a syrup to the soda fountain to start processing -->\
> \<VBE_CancelBringingSyrup>Bring a syrup to the soda fountain to start processing</VBE_CancelBringingSyrup>\
> \<!-- EN: Cancel Bringing Syrup -->\
> \<VBE_CancelBringingSyrupDesc>Cancel Bringing Syrup</VBE_CancelBringingSyrupDesc>\
> \<!-- EN: Cancel bringing syrup to the soda fountain. -->\
> \<VBE_SyrupFailurePower>Cancel bringing syrup to the soda fountain.</VBE_SyrupFailurePower>
