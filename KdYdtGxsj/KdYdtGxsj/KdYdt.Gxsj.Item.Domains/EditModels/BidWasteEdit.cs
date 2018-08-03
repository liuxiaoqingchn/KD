using KdCore.Data.EditModels;
using KdCore.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KdYdt.Gxsj.Item.Domains.EditModels
{
   public class BidWasteEdit: KdBaseEdit
    {
        /// <summary>
        /// 废标原因
        /// </summary>
        [Display(Name = "废标原因")]
        [DataType(DataType.MultilineText)]
        [MaxLength(1000)]
        public virtual string WasteReason { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(1000)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "备注")]
        public virtual string Explain { get; set; }
    }
}
