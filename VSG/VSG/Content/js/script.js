const btn = document.querySelectorAll("button")
//console.log(btn)
btn.forEach(function (button, index) {
    //console.log(button, index)
    button.addEventListener("click", function (event) {
        {
            var btnItem = event.target
            var product = btnItem.parentElement
            var productImg = product.querySelector("img").src
            var productName = product.querySelector("h1").innerText
            var productPrice = product.querySelector("span").innerText
            //console.log(productPrice,productImg,productName)
            addgiohang(productPrice,productImg,productName)
    } })
})
function addgiohang(productPrice,productImg,productName){
    var addtr = document.createElement("tr")
    var giohangItem = document.querySelectorAll("tbody tr")
    for(var i = 0 ; i < giohangItem.length;i++){//kiem tra số lượng có trong giỏ hàng
        var productT = document.querySelectorAll(".title")
        if(productT[i].innerHTML == productName){
            alert("sản phẩm của bạn đã có trong giỏ hàng")//thông báo khi trùng sản phẩm
            return
        }
    }
    var trcontent = '  <tr><td style="display:flex;align-items:center;"><img style="width:70px;" src="'+productImg+'" alt="" /><span class ="title">'+productName+'</span></td><td><p><span class="price">'+productPrice+'</span><sup>vnd</sup></p></td><td><input style="width:30px;outline:none;" type="number" value="1" min="1"></td><td style="cursor:pointer;"><span class ="cart-delete">Xóa</span></td></tr>'
    addtr.innerHTML = trcontent//doi noi dung
    var giohangTable = document.querySelector("tbody")
     //console.log(giohangTable);
     giohangTable.append(addtr)

     giohangTong()
     deleteGH()
}

//--------------------tính tong------------------//
function giohangTong(){
    var giohangItem = document.querySelectorAll("tbody tr")
    var TongCong = 0;
    //console.log(giohangItem.length)
    //vong lap cho tinh tong
    for(var i = 0 ; i < giohangItem.length;i++){
        //console.log(i)
        //lay gia trị của thẻ tr trong tbody (input)
        var inputValue = giohangItem[i].querySelector("input").value
        //console.log(inputValue)
        //lay the span trong tr
        var productPrice = giohangItem[i].querySelector(".price").innerHTML
        //console.log(productPrice)
        //tổng nhân cua so lương và giá của sản phẩm
        TongnhanA = inputValue*productPrice*1000
        //console.log(TongnhanA)
        //TongnhanB = TongnhanA.toLocaleString('de-DE')//hàm tham khảo trên mạng để giá có dấu chấm (.)
        //console.log(TongnhanB)
        TongCong = TongCong+TongnhanA
        //TongnhanB = TongCong.toLocaleString('de-DE')
        //console.log(TongCong)
    }
    var Tonggiatrigiohang = document.querySelector(".gia span")
    Tonggiatrigiohang.innerHTML = TongCong.toLocaleString('de-DE')
    //console.log(Tonggiatrigiohang)
    inputchange()//gọi hàm thay doi số lượng và giá trị
}
//---------------------XOA----------------------//
function deleteGH(){
    var giohangItem = document.querySelectorAll("tbody tr")
    for(var i = 0 ; i < giohangItem.length;i++){//kiem tra số lượng có trong giỏ hàng
        var productT = document.querySelectorAll(".cart-delete")
        productT[i].addEventListener("click",function(event){
            var XoaGH1 = event.target
            var XoaGH2 = XoaGH1.parentElement.parentElement
            XoaGH2.remove()
            giohangTong()
            //console.log(XoaGH2)
        })
     
    }
}
function inputchange(){
    var giohangItem = document.querySelectorAll("tbody tr")
    for(var i = 0 ; i < giohangItem.length;i++){//kiem tra số lượng có trong giỏ hàng
        var inputValue = giohangItem[i].querySelector("input")
        inputValue.addEventListener("change",function(){
            giohangTong()
        })
     
    }
}