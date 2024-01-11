var h6Elements = document.getElementsByTagName('h6');
for (var i = 0; i < h6Elements.length; i++) {
    if (h6Elements[i].textContent.includes('NAPOMENA:')) {
        h6Elements[i].style.display = 'none';
    }
}