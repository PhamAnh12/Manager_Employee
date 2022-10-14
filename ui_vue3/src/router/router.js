import EmployeeList from '../components/page/employee/EmployeeList.vue'
import Overview from '../components/page/pageOther/Overview.vue'
import Deposits from '../components/page/pageOther/Deposits.vue'
import Purchase from '../components/page/pageOther/Purchase.vue'
import Sale from '../components/page/pageOther/Sale.vue'
import Management from '../components/page/pageOther/Management.vue'
import Warehouse from '../components/page/pageOther/Warehouse.vue'
import Tool from '../components/page/pageOther/Tool.vue'
import Fixed_assets from '../components/page/pageOther/FixedAssets.vue'
import Tax from '../components/page/pageOther/Tax.vue'
import Pice from  '../components/page/pageOther/Pice.vue'
import Synthetic from '../components/page/pageOther/Synthetic.vue'
import Budget from '../components/page/pageOther/Budget.vue'
import Report from '../components/page/pageOther/Report.vue'
import Financial_analysis from '../components/page/pageOther/FinancialAnalysis.vue'


import {createRouter,createWebHistory} from "vue-router"
// Định nghĩa router:
const routers = [
    {path:"/",component: Overview },
    {path:"/employees",component: EmployeeList},
    {path:"/deposits",component: Deposits },
    {path:"/purchase",component:  Purchase },
    {path:"/sale",component: Sale },
    {path:"/management",component: Management },
    {path:"/warehouse",component: Warehouse },
    {path:"/tool",component: Tool },
    {path:"/fixed-assets",component: Fixed_assets },
    {path:"/tax",component: Tax },
    {path:"/pice",component: Pice },
    {path:"/synthetic",component: Synthetic },
    {path:"/budget",component: Budget},
    {path:"/report",component: Report },
    {path:"/financial-analysis",component: Financial_analysis },
    
]
// Khỏi tạo router 
 const router = createRouter({
    history: createWebHistory(),
    routes: routers,
    linkActiveClass: 'active-link',
    linkExactActiveClass: 'exact-active-link',
 })
 export default router
 