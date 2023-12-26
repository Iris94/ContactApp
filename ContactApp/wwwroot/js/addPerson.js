

document.getElementById("addNewPerson").addEventListener("click", function () {
    const phoneNumbers = Array.from(document.querySelectorAll('.phone-number-input')).map(input => {
        return { Phone: input.value };
    });

    const emailAddresses = Array.from(document.querySelectorAll('.email-address-input')).map(input => {
        return { Email: input.value };
    });


    const FormData = {
        FirstName: document.getElementById('firstName').value,
        LastName: document.getElementById('lastName').value,
        Sex: document.querySelector('input[name="sexGender"]:checked').value,
        State: document.getElementById('stateDropdown').value,
        City: document.getElementById('cityDropdown').value,
        Birthday: document.getElementById('birthday').value,
        Age: document.getElementById('age').value,
        PhoneNumbers: phoneNumbers,
        EmailAddresses: emailAddresses
    };

    fetch('/api/persons', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(FormData),
    })
        .then(response => {
            if (!response.ok) {
                throw new Error(`HTTP error! Status: ${response.status}`);
            }
            return response.json();
        })
        .then(data => {
            console.log('Success:', data);
        })
        .catch(error => {
            console.error('Error:', error);
        })
});


function addEmailAddress() {
    const container = document.getElementById('emailAddressesContainer');
    const input = document.createElement('div');
    const emailInput = document.createElement('input');

    emailInput.type = 'email';
    emailInput.className = 'form-control email-address-input';
    emailInput.name = 'Email';
    emailInput.maxLength = '50';
    emailInput.placeholder = 'aaa@bbb.ccc';
    emailInput.required = true;

    input.appendChild(emailInput);
    container.appendChild(input);
}


function addPhoneNumber() {
    const container = document.getElementById('phoneNumbersContainer');
    const input = document.createElement('div');

    const phoneNumberInput = document.createElement('input');
    phoneNumberInput.type = 'tel';
    phoneNumberInput.className = 'form-control phone-number-input';
    phoneNumberInput.name = 'PhoneNumber';
    phoneNumberInput.pattern = '[0-9]{3}/[0-9]{3}-[0-9]{3}';
    phoneNumberInput.maxLength = '11';
    phoneNumberInput.placeholder = 'xxx/xxx-xxx';
    phoneNumberInput.required = true;

    input.appendChild(phoneNumberInput);
    container.appendChild(input);
}

