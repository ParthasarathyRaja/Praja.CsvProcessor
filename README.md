# Praja.CsvProcessor

Assumptions

1. Since Recreo develops applications which shows multiple superannuation account detqails and tax details under one umbreslla, 
I have taken three CSV files which are assumed as received from three super providers IRESS, Australian Super and Class Super. 
These transactions will be inserted into three tables via thrre entity framework dbsets.

2. Column names in these CSV files will differ, but the transactions are almost similar. The csv processor/helper will take 
care of mapping them to respective entities.

3. Unit tests were not added because of short notice. If time is given, i am happy to add unit test project and complete it.
