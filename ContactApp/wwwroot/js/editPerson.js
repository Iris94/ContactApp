

function editPerson(personID) {
    fetch(`/api/persons/${personID}`)
        .then(response => response.json())
        .then(data => {
            $('#editPhoneNumbersContainer').empty();
            $('#editEmailAddressesContainer').empty();
            populateEditModal(data);
            $('#editModal').modal('show');
            $('#saveChangesButton').on('click', () => saveEditedPerson(personID));
        })
        .catch(error => {
            console.error('Error fetching person data:', error);
        });
}

function populateEditModal(data) {
    $('#editFirstName').val(data.firstName);
    $('#editLastName').val(data.lastName);
    data.phoneNumbers.forEach(phone => addPhoneNumberInput(phone));
    data.emailAddresses.forEach(email => addEmailAddressInput(email));
    $('#editSexDropdown').val(data.sex);
    $('#editStateDropdown').val(data.state);
    editCitiesDropdown(data.state, data.city); 
    $('#editCityDropdown').val(data.city);
    $('#editBirthday').val(data.birthday);

    const birthDate = new Date(data.birthday);
    const today = new Date();
    const age = today.getFullYear() - birthDate.getFullYear();
    $('#editAge').val(age);
}


function addPhoneNumberInput(phone) {
    const container = $('#editPhoneNumbersContainer');
    const input = $('<input>').attr({
        type: 'tel',
        class: 'form-control edit-phone-number-input',
        name: 'PhoneNumber',
        pattern: '[0-9]{3}/[0-9]{3}-[0-9]{3}',
        maxlength: '11',
        placeholder: 'xxx/xxx-xxx',
        value: phone,
        required: true
    });
    container.append($('<div>').append(input));
}

function addEmailAddressInput(email) {
    const container = $('#editEmailAddressesContainer');
    const input = $('<input>').attr({
        type: 'email',
        class: 'form-control edit-email-address-input',
        name: 'Email',
        maxlength: '50',
        placeholder: 'aaa@bbb.ccc',
        value: email,
        required: true
    });
    container.append($('<div>').append(input));
}




async function editStatesDropdown() {
    const response = await fetch('/api/statecity/states');
    const states = await response.json();

    const stateDropdown = document.getElementById('editStateDropdown');
    states.forEach(state => {
        const option = document.createElement('option');
        option.value = state;
        option.textContent = state;
        stateDropdown.appendChild(option);
    });
}


async function editCitiesDropdown(selectedState, selectedCity) {
    const response = await fetch(`/api/statecity/cities?state=${selectedState}`);
    const cities = await response.json();
    let setCity;

    if (selectedCity) {
        setCity = selectedCity
    } else {
        const randomIndex = Math.floor(Math.random() * cities.length);
        setCity = cities[randomIndex];
    }

    const cityDropdown = document.getElementById('editCityDropdown');
    cityDropdown.innerHTML = `<option value="${setCity}" selected>${setCity}</option>`;
    cities.forEach(city => {
        if (city === setCity) return;
        const option = document.createElement('option');
        option.value = city;
        option.textContent = city;
        cityDropdown.appendChild(option);
    });
}

document.getElementById('editStateDropdown').addEventListener('change', function () {
    const selectedState = this.value;
    editCitiesDropdown(selectedState);
});


editStatesDropdown()