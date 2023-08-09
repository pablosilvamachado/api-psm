using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_psm.infra.data.Enum
{
    internal enum DataAccessProviderTypes
    {
        SqlServer,
        SqLite,
        MySql,
        PostgreSql,
#if NETFULL
    OleDb,
    SqlServerCompact
#endif
    }
}
