

function saveEditedPerson(personID) {
    const phoneNumbers = Array.from(document.querySelectorAll('.edit-phone-number-input')).map(input => {
        return { Phone: input.value };
    });

    const emailAddresses = Array.from(document.querySelectorAll('.edit-email-address-input')).map(input => {
        return { Email: input.value };
    });

    const EditedPerson = {
        FirstName: document.getElementById('editFirstName').value,
        LastName: document.getElementById('editLastName').value,
        Sex: document.getElementById('editSexDropdown').value,
        State: document.getElementById('editStateDropdown').value,
        City: document.getElementById('editCityDropdown').value,
        Birthday: document.getElementById('editBirthday').value,
        Age: document.getElementById('editAge').value,
        PhoneNumbers: phoneNumbers,
        EmailAddresses: emailAddresses
    };

    fetch(`/api/persons/${personID}`, {
        method: 'PATCH',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(EditedPerson),
    })
        .then(response => response.json())
        .then(updatedPerson => {
            $('#editModal').modal('hide');
            console.log(updatedPerson)
        })
        .catch(error => {
            console.error('Error updating person:', error);
        });
}
