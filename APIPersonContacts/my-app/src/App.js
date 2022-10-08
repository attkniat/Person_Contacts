import React, { useState } from "react";

export default function App() {

  const [contacts, setContacts] = useState([]);

  function getContacts() {
    //const url = Constants.API_URL_GET_ALL_POSTS;
    const url = 'https://localhost:7168/get-all-contacts';

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

  return (
    <div className='container'>
      <div className='row min-vh-100'>
        <div className="col d-flex flex-column justify-content-center align-items-center">
          <div>
            <h1>Contacts Crud</h1>
            <div className="mt-5">
              <button onClick={getContacts} className='btn btn-dark btn-lg w-100'>Get all Contacts</button>
              <button onClick={getContacts} className='btn btn-secondary btn-lg w-100 mt-4'>New</button>
              {/* <button onClick={() => setShowingCreateNewPostForm(true)} className="btn btn-secondary btn-lg w-100 mt-4">Create New Post</button> */}
            </div>
          </div>
          {contacts.length > 0 && renderContactsTable()}
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
                  {/* <button onClick={() => setPostCurrentlyBeingUpdated(contact)} className="btn btn-dark btn-lg mx-3 my-3">Update</button> }
                  <button onClick={() => { if (window.confirm(`Are you sure you want to delete the post titled "${contact.title}"?`)) deletePost(contact.contactId) }} className="btn btn-secondary btn-lg">Delete</button> */}
                  <button className="btn btn-dark btn-lg mx-3 my-3">Update</button>
                  <button className="btn btn-secondary btn-lg">Delete</button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>

        <button onClick={() => setContacts([])} className="btn btn-dark btn-lg w-100">Empty React contact array</button>
      </div>
    );
  }
}
