<template>
   <div class="navbar">
            <div class="navbar-header">
                <div class="item-icon icon-24 ">
                    <div class="  icon icon-total"></div>
                </div>

                <div class="navbar-header-content">
                    <a href="/" class="item-link-logo">
                    <img class="item-logo" src="../../assets/img/Logo_Module_TiengViet_White.66947422.svg" alt="" />
                    </a>                  
                </div>
            </div>
               <div class="navbar-main">
                <router-link to="/" class="navbar-item " refs="item-navbar"  v-tooltip="'Tổng quan'">
                    <div class="item-icon icon-24">
                        <div class="icon icon-overview" ></div>
                    </div>
                    <div class="navbar-item-text">Tổng quan</div>
                </router-link>
                <router-link to="/employees" class="navbar-item "  
                v-tooltip="{
                 content:'Nhân viên',
                
                 }">
                    <div class="item-icon icon-24">
                        <div class=" icon icon-employee"></div>
                    </div>
                    <div class="navbar-item-text">Nhân viên</div>
                </router-link>

                <router-link to="/deposits" class="navbar-item"  v-tooltip="'Tiền gửi'">
                    <div class="item-icon icon-24">
                        <div class="icon icon-deposits"></div>
                    </div>
                    <div class="navbar-item-text">Tiền gửi</div>
                </router-link>
                <router-link to="/purchase" class="navbar-item"    v-tooltip="'Mua hàng'">
                    <div class="item-icon icon-24">
                        <div class="icon icon-purchase"></div>
                    </div>
                    <div class="navbar-item-text">Mua hàng</div>
                </router-link>
                <router-link to="/sale" class="navbar-item"  v-tooltip="'Bán hàng'">
                    <div class="item-icon icon-24">
                        <div class="icon icon-sale"></div>
                    </div>
                    <div class="navbar-item-text">Bán hàng</div>
                </router-link>
                <router-link to="/management" class="navbar-item"  v-tooltip="'Quản lý hóa đơn'">
                    <div class="item-icon icon-24">
                        <div class="icon icon-management"></div>
                    </div>
                    <div class="navbar-item-text">Quản lý hóa đơn</div>
                </router-link>
                <router-link to="/warehouse" class="navbar-item" v-tooltip="'Kho'">
                    <div class="item-icon icon-24"> 
                        <div class="icon icon-warehouse"></div>
                    </div>
                    <div class="navbar-item-text">Kho</div>
                </router-link>
                <router-link to="/tool" class="navbar-item"   v-tooltip="'Công cụ dụng cụ chi phí trả trước'">
                    <div class="item-icon icon-24">
                        <div class="icon icon-tool"></div>
                    </div>
                    <div class="navbar-item-text">Công cụ dụng cụ</div>
                </router-link>
                <router-link to="/fixed-assets" class="navbar-item" v-tooltip="'Tài sản cố định'">
                    <div class="item-icon icon-24">
                        <div class="icon icon-fixed-assets"></div>
                    </div>
                    <div class="navbar-item-text">Tài sản cố định</div>
                </router-link>
                <router-link to="/tax" class="navbar-item"   v-tooltip="'Thuế'">
                    <div class="item-icon icon-24">
                        <div class="icon icon-tax"></div>
                    </div>
                    <div class="navbar-item-text">Thuế</div>
                </router-link>
                <router-link to="/pice" class="navbar-item"  v-tooltip="'Giá Thành'">
                    <div class="item-icon icon-24">
                        <div class=" icon icon-pice"></div>
                    </div>
                    <div class="navbar-item-text">Giá thành</div>
                </router-link>
                <router-link to="/synthetic" class="navbar-item"  v-tooltip="'Tổng hợp'">
                    <div class="item-icon icon-24">
                        <div class="icon icon-synthetic"></div>
                    </div>
                    <div class="navbar-item-text">Tổng hợp</div>
                </router-link>
                <router-link to="/budget" class="navbar-item"  v-tooltip="'Ngân sách'">
                    <div class="item-icon icon-24">
                        <div class="icon icon-budget"></div>
                    </div>
                    <div class="navbar-item-text" >Ngân sách</div>
                </router-link>
                <router-link to="/report" class="navbar-item"  v-tooltip="'Báo cáo'">
                    <div class="item-icon icon-24">
                        <div class="icon icon-report"></div>
                    </div>
                    <div class="navbar-item-text">Báo cáo</div>
                </router-link>
                <router-link to="/financial-analysis" class="navbar-item" v-tooltip="'Phân tích tài chính'">
                    <div class="item-icon icon-24">
                        <div class="icon icon-analysis"></div>
                    </div>
                    <div class="navbar-item-text">Phân tích tài chính</div>
                </router-link>
            </div>
        </div>
</template>
<script>
export default {
  name: "t-navbar",
};
</script>
<style>
</style>