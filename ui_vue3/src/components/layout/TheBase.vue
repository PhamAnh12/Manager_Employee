<template>
    <div class="base">
    <div class="container-icon">
    <h3>I.Icon</h3>
    <div class="item-icon icon-24">
    <div class=" icon icon-help"></div>
    </div>
    </div>
    <div class="container-button" style="margin-top:10px">
    <h3>II.Button</h3>
    <div class="btn btn-primary">
     Thêm  nhân viên
    </div>
    <div class="btn btn-extra" style="margin-top:10px"> Button </div>
    </div>
    <div class="container-input" style="margin-top:10px">
    <label class="input-label" for="">Input <span class="input-required">*</span></label>
    <input type="text" class="input" placeholder="Nhập họ tên" >
    </div>
     <div class="container-input" style="margin-top:10px">
    <label class="input-label" for="">Input <span class="input-required">*</span></label>
    <input type="text" class="input input-error" placeholder="Nhập họ tên" >
    </div>
    <div class="container-input" style="margin-top:10px">
    <input type="text" class="input input-icon" placeholder="Nhập mã,họ tên" >
    <div class="item-icon icon-20 input-icon-search">
    <div class="icon icon-search"></div>
    </div>
    </div>
    <div style="margin-top:10px">
    <input  type="checkbox" class="checkbox-24">
    </div>
     <div style="margin-top:10px">
    <input  type="radio" >
    </div>
    </div>
</template>
<script>

export default {
    name:"t-base"
}
</script>
