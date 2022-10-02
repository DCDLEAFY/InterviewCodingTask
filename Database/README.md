# MySQL Database

The database table below was generated from converting the JSON file received from the client into a table. From the data provided I made an assumption that there are only a handful amount of PolicyTypes that can be chosen and as a result constricted the available options as such(ENUM). For now the ENUM has only two option, however when more information about the policytype is available, the ENUM will be updated to include those.

## Database Table

Database Name: *InsuranceBrokerageDB*

Database Table: *Customer*

*Customer* Table Information

| Data Type  | Data Name  | Data Properties |
|---|---|---|
| int(15) | Id | NOT NULL AUTO_INCREMENT |
| varchar(50) | Name | DEFAULT NULL |
| varchar(50) | Address | DEFAULT NULL |
| ENUM("Public Liability", "Motor Fleet") | PolicyType | DEFAULT NULL |
| varchar(50) | InsurerName | DEFAULT NULL |
| double | Premium | DEFAULT NULL |

*Customer* Table View

| id      | Name | Address | PolicyType | InsurerName | Premium |  
| ----------- | ----------- | ----------- | ----------- | ----------- | ----------- |
| 1      | XYZ Plumbing       | 24 Fleet Street, Glasgow | Public Liability | Allianz | 2321.45 |


