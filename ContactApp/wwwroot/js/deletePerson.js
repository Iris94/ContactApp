

function delPerson(personID) {
    $('#deleteModal').modal('show');
    $("#deletePersonFromDb").on('click', () => deleteFetch(personID))
}

function deleteFetch(personID) {
    fetch(`/api/persons/${personID}`, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
        },
    })
        .then(response => {
            if (!response.ok) {
                throw new Error(`Status: ${response.status}`);
            }
            $('#deleteModal').modal('hide');
            console.log('Person deleted successfully');
        })
        .catch(error => {
            console.error('Error deleting person:', error);
        });
}



