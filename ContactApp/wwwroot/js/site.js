

async function populateStatesDropdown() {
    const response = await fetch('/api/statecity/states');
    const states = await response.json();

    const stateDropdown = document.getElementById('stateDropdown');
    states.forEach(state => {
        const option = document.createElement('option');
        option.value = state;
        option.textContent = state;
        stateDropdown.appendChild(option);
    });
}


async function populateCitiesDropdown(selectedState) {
    const response = await fetch(`/api/statecity/cities?state=${selectedState}`);
    const cities = await response.json();

    const cityDropdown = document.getElementById('cityDropdown');
    cityDropdown.innerHTML = '<option value="" selected>Select City</option>';

    cities.forEach(city => {
        const option = document.createElement('option');
        option.value = city;
        option.textContent = city;
        cityDropdown.appendChild(option);
    });
}

document.getElementById('stateDropdown').addEventListener('change', function () {
    const selectedState = this.value;
    populateCitiesDropdown(selectedState);
});

document.getElementById('birthday').addEventListener('change', function () {
    const selectedDate = new Date(this.value);

    const today = new Date();
    const age = today.getFullYear() - selectedDate.getFullYear();

    document.getElementById('age').value = age;
});

populateStatesDropdown();







