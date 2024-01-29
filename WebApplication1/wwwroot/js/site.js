var items = JSON.parse(localStorage.getItem("items")) || [];
function addToCart(item) {
    items.push(item);
    localStorage.setItem("items", JSON.stringify(items));
    toastr.success('Item add successfully in Cart', 'success');

}