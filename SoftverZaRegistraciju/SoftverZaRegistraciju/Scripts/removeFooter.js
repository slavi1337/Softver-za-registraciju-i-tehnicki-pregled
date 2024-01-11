var footers = document.querySelectorAll('div[style*="position: absolute; bottom:0px;"]');
for (var i = 0; i < footers.length; i++) {
    footers[i].style.display = 'none';
}