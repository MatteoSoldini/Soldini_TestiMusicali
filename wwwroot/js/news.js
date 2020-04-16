const uri = 'api/Lyrics';

function getItems() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayItems(data))
        .catch(error => console.error('Unable to get items.', error));
}

function _displayCount(itemCount) {
    const name = (itemCount === 1) ? 'Testo musicale' : 'Testi musicali';

    document.getElementById('counter').innerText = `${itemCount} ${name}`;
}

function _displayItems(data) {
    const tBody = document.getElementById('lyrics');
    tBody.innerHTML = '';

    _displayCount(data.length);

    const button = document.createElement('button');

    data.forEach(item => {
        let isCompleteCheckbox = document.createElement('input');
        isCompleteCheckbox.type = 'checkbox';
        isCompleteCheckbox.disabled = true;
        isCompleteCheckbox.checked = item.isComplete;


        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', 'window.location.href = "/Lyrics/Edit?id=' + item.id + '"');

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', 'window.location.href = "/Lyrics/Delete?id=' + item.id + '"');

        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        var textNode = document.createTextNode(item.song);
        td1.appendChild(textNode);

        let td2 = tr.insertCell(1);
        var textNode = document.createTextNode(item.artist);
        td2.appendChild(textNode);

        let td3 = tr.insertCell(2);
        var textNode = document.createTextNode(item.writer);
        td3.appendChild(textNode);

        let td4 = tr.insertCell(3);
        var textNode = document.createTextNode(item.release_date);
        td4.appendChild(textNode);

        let td5 = tr.insertCell(4);
        var textNode = document.createTextNode(item.text);
        td5.appendChild(textNode);

        let td6 = tr.insertCell(5);
        td6.appendChild(editButton);

        let td7 = tr.insertCell(6);
        td7.appendChild(deleteButton);
    });

    lyrics = data;
}