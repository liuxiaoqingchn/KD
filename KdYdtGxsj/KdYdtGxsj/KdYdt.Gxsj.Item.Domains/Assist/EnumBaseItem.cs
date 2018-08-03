using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KdYdt.Gxsj.Item.Domains.Assist
{
    /// <summary>
    /// 任务完成状态
    /// </summary>
    public enum EnumTaskStatus
    {
        None,
        未开始,
        进行中,
        已完成
    }

    /// <summary>
    /// 标书类别
    /// </summary>
    public enum EnumBidingType
    {
        None,
        技术标,
        商务标,
        资信标,
        设计标,
        封标
    }
    /// <summary>
    /// 是否中标
    /// </summary>
    public enum EnumIsBiding
    {
        None,
        未入围,
        废标,
        未中标,
        中标
    }
    /// <summary>
    /// 项目进行状态
    /// </summary>
    public enum EnumPrjStatus
    {
        None,
        已立项,
        已投标,
        已完成且已中标,
        已完成未中标
    }

    public enum EnumPaySum
    {
        None,
        支出汇总,
        收入汇总
    }
}
