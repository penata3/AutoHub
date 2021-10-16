
    var showAdditions = false;
    var containerToShow = this.document.getElementsByClassName('containerToShow')[0];
    var btn = this.document.getElementsByClassName('showMoreButton')[0];

    btn.addEventListener('click', (event) =>
    {
        event.preventDefault();

    showAdditions = !showAdditions;

    if (showAdditions) {
        containerToShow.classList.remove('hidden');
        btn.innerText = 'Hide';
        }
    else {
        containerToShow.classList.add('hidden');
    btn.innerText = 'Show more';
        }                  
    })
