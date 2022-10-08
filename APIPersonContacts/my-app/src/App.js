import React, { useState } from "react";
import Constants from "./Utilities/Constants";
import ContactCreateForm from "./Components/ContactCreateForm";
import ContactUpdateForm from "./Components/PostUpdateForm";

export default function App() {

  const [contacts, setContacts] = useState([]);
  const [showingCreateNewContactForm, setShowingCreateNewContactForm] = useState(false);
  const [contactCurrentlyBeingUpdated, setContactCurrentlyBeingUpdated] = useState(null);

  function getContacts() {
    const url = Constants.API_URL_GET_ALL_CONTACTS;

    fetch(url, {
      method: 'GET'
    })
      .then(response => response.json())
      .then(contactsFromServer => {
        setContacts(contactsFromServer);
      })
      .catch((error) => {
        console.log(error);
        alert(error);
      });
  }

  function deleteContact(contactId) {
    const url = `${Constants.API_URL_DELETE_CONTACT_BY_ID}/${contactId}`;
  debugger;
    fetch(url, {
      method: 'DELETE'
    })
      .then(response => response.json())
      .then(responseFromServer => {
        console.log(responseFromServer);
        onContactDeleted(contactId);
      })
      .catch((error) => {
        console.log(error);
        alert(error);
      });
  }

  return (
    <div className='container'>
      <div className='row min-vh-100'>
        <div className="col d-flex flex-column justify-content-center align-items-center">
          {(showingCreateNewContactForm === false && contactCurrentlyBeingUpdated === null) && (
            <div>
              <h1>React Contacts Crud</h1>
              <div className="mt-5">
                <button onClick={getContacts} className='btn btn-dark btn-lg w-100'>Get all Contacts</button>
                <button onClick={() => setShowingCreateNewContactForm(true)} className="btn btn-secondary btn-lg w-100 mt-4">New Contact</button>
              </div>
            </div>
          )}

          {(contacts.length > 0 && showingCreateNewContactForm === false && contactCurrentlyBeingUpdated === null) && renderContactsTable()}
          {showingCreateNewContactForm && <ContactCreateForm onContactCreated={onContactCreated} />}
          {contactCurrentlyBeingUpdated !== null && <ContactUpdateForm contact={contactCurrentlyBeingUpdated} onContactUpdated={onContactUpdated} />}
        </div>
      </div>
    </div>
  );

  function renderContactsTable() {
    return (
      <div className="table-responsive mt-5">
        <table className="table table-bordered border-dark">
          <thead>
            <tr>
              <th scope="col">Contact Id (PK)</th>
              <th scope="col">Name</th>
              <th scope="col">Email</th>
              <th scope="col">Phone</th>
              <th scope="col">Actions</th>
            </tr>
          </thead>
          <tbody>
            {contacts.map((contact) => (
              <tr key={contact.contactId}>
                <th scope="row">{contact.contactId}</th>
                <td>{contact.personName}</td>
                <td>{contact.personEmail}</td>
                <td>{contact.personPhone}</td>
                <td>
                  <button onClick={() => setContactCurrentlyBeingUpdated(contact)} className="btn btn-dark btn-lg mx-3 my-3">Update</button>
                  <button onClick={() => { if (window.confirm(`Are you sure you want to delete the contact named "${contact.personName}"?`)) deleteContact(contact.contactId) }} className="btn btn-secondary btn-lg">Delete</button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>

        <button onClick={() => setContacts([])} className="btn btn-dark btn-lg w-100">Empty React contact array</button>
      </div>
    );
  }

  function onContactCreated(createdContact) {
    setShowingCreateNewContactForm(false);

    if (createdContact === null) {
      return;
    }
    debugger;
    alert(`Post successfully created. After clicking OK, your new Contact of "${createdContact.personName}" will show up in the table below.`);

    getContacts();
  }

  function onContactUpdated(updatedContact) {
    setContactCurrentlyBeingUpdated(null);

    if (updatedContact === null) {
      return;
    }

    let contactsCopy = [...contacts];

    const index = contactsCopy.findIndex((contactsCopyPost, currentIndex) => {
      if (contactsCopyPost.postId === updatedContact.contactId) {
        return true;
      }
    });

    if (index !== -1) {
      contactsCopy[index] = updatedContact;
    }

    setContacts(contactsCopy);

    alert(`Contact successfully updated. After clicking OK, look for the contact of the "${updatedContact.personName}" in the table below to see the updates.`);
  }

  function onContactDeleted(deletedContactId) {
    let contractCopy = [...contacts];
  
    const index = contractCopy.findIndex((contactsCopyConts, currentIndex) => {
      if (contactsCopyConts.postId === deletedContactId) {
        return true;
      }
    });
  
    if (index !== -1) {
      contractCopy.splice(index, 1);
    }
  
    setContacts(contractCopy);
  
    alert('Contact successfully deleted. After clicking OK, look at the table below to see your contact disappear.');
  }
}
