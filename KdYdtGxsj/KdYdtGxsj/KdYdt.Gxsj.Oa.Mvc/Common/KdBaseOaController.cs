using KdCore.Data;
using KdCore.Data.EditModels;
using KdCore.Data.Entity;
using KdCore.Web.Mvc;

using KdYdt.Gxsj.Oa.Domains.Services;

namespace KdYdt.Gxsj.Oa.Mvc
{
    public abstract class KdBaseOaController : KdBaseController<PrjDbOaService>
    {
    }

    public abstract class KdBaseOaController<TEntity, TEditModel>
        : KdEntityController<PrjDbOaService, TEntity, TEditModel>
        where TEntity : class, IKdEntityModify, IKdEntityFollow, new()
        where TEditModel : KdBaseEdit, new()
    {
    }
}
