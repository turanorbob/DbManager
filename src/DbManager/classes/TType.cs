using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbManager.classes
{
    enum ENodeType { DATABASE, TABLE, VIEW, PROGRAME, PROCEDURE, FIELD, PARAMETER };
    enum ENumberField { BIT, TINYINT, SMALLINT, INT, BIGINT, NUMERIC, DECIMAL, SMALLMONEY, MONEY };
    enum EFloatNumberField { FLOAT, REAL };
    enum EDatetimeField { DATETIME, SMALLDATETIME };
    enum EStringField { CHAR, VARCHAR, TEXT };
    enum EUnicodeField { NCHAR, NVARCHAR, NTEXT };
    enum EBinaryField { BINARY, VARBINARY, IMAGE };
    enum EOtherField { SQL_VARIANT, TIMESTAMP, UNIQUEIDENTIFIER, XML };
}
