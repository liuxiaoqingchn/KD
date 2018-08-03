using System.Linq;
using KdCore;
using KdYdt.Gxsj.Item.Domains.Models;
using KdYdt.Gxsj.Item.Domains.EditModels;
using System.Web.Mvc;

namespace KdYdt.Gxsj.Item.Mvc.Areas.Item.Controllers
{
    [KdUnitGroup("企业信息", 370)]
    public class CorpController : ItemBaseController<PrjCorp, PrjCorpEdit>
    {
        protected override void OnDataEntityView(PrjCorp entity)
        {
            if (entity != null)
            {
                entity.Persons = this.DbService.ValidQuery<PrjPerson>(x => x.CorpId == entity.Id).ToList();
                entity.Aptitudes = this.DbService.ValidQuery<PrjAptitude>(x => x.CorpId == entity.Id).ToList();
                entity.Facilitys = this.DbService.ValidQuery<PrjFacility>(x => x.CorpId == entity.Id).ToList();
                entity.Praises = this.DbService.ValidQuery<PrjPraise>(x => x.CorpId == entity.Id).ToList();
            }
            base.OnDataEditView(entity);
        }  
        [KdAction("查阅")]
        public ActionResult PersonView(string id)
        {
            return base.DataEntityView<PrjPerson>(id);
        }

        [KdAction("查阅")]
        public ActionResult FacilityView(string id)
        {
            return base.DataEntityView<PrjFacility>(id);
        }
        [KdAction("查阅")]
        public ActionResult AptitudeView(string id)
        {
            return base.DataEntityView<PrjAptitude>(id);
        }
        [KdAction("查阅")]
        public ActionResult PraiseView(string id)
        {
            return base.DataEntityView<PrjPraise>(id);
        }
    }
}
