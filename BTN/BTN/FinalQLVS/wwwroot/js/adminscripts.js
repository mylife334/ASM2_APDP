function toggleMenu(menuId) {
    var menus = document.querySelectorAll('.has-submenu');
    menus.forEach(function(menu) {
        if (menu.id !== menuId) {
            menu.classList.remove('active');
        }
    });
    var element = document.getElementById(menuId);
    element.classList.toggle('active');
}
    
 