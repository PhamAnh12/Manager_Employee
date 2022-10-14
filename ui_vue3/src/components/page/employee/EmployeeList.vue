<template>
  <div class="content">
    <div class="content-header">
      <div class="content-header-text">Nhân viên</div>
      <div class="btn btn-primary content-center">Thêm mới nhân viên</div>
    </div>
    <div class="content-body">
      <div class="container-sidebar">
        <div class="sidebar-left">
          <div class="sidebar-delete-list">
            <div class="delete-list-text">Thực hiện hàng loạt</div>
            <div class="item-icon icon-16"></div>
          </div>
          <!-- <div class="delete-list">Xóa</div> -->
        </div>
        <div class="sidebar-right">
          <div class="container-input" >
            <input
              type="text"
              class="input input-icon"
              placeholder="Tìm theo mã, tên nhân viên"
            />
            <div class="item-icon icon-20 input-icon-search">
              <div class="icon icon-search"></div>
            </div>
          </div>
          <div class="btn-sidebar">
            <div
              class="item-icon btn-sidebar-item icon-36"
              v-tooltip="{
                content: 'Load lại dữ liệu',
              }"
            >
              <div class="icon icon-load"></div>
            </div>
            <div
              class="item-icon btn-sidebar-item icon-36"
              v-tooltip="{
                content: 'Xuất ra Excel',
              }"
            >
              <div class="icon icon-export"></div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  name: "p-employeeList",
};
</script>