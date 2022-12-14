import React, { useState } from 'react'
import Constants from '../Utilities/Constants'

export default function ContactCreateForm(props) {
        
    const initialFormData = Object.freeze({
        Name: "Jack",
        Email: "jack@gmail.com",
        Phone: "1234567890"
    });
    
    const [formData, setFormData] = useState(initialFormData);

    const handleChange = (e) => {
        setFormData({
            ...formData,
            [e.target.name]: e.target.value,
        });
    };

    const handleSubmit = (e) => {
        e.preventDefault();

        const contactToCreate = {
            contactId: 0,
            personName: formData.Name,
            personEmail: formData.Email,
            personPhone: formData.Phone
        };

        const url = Constants.API_URL_CREATE_CONTACT;

        fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(contactToCreate)
        })
            .then(response => response.json())
            .then(responseFromServer => {
                console.log(responseFromServer);
            })
            .catch((error) => {
                console.log(error);
                alert(error);
            });

        props.onContactCreated(contactToCreate);
    };

    return (
        <form className="w-50 px-5">
            <h1 className="mt-5">Create new Contact</h1>

            <div className="mt-5">
                <label className="h3 form-label">Name</label>
                <input value={formData.Name} name="Name" type="text" className="form-control" onChange={handleChange} />
            </div>

            <div className="mt-5">
                <label className="h3 form-label">Email</label>
                <input value={formData.Email} name="Email" type="text" className="form-control" onChange={handleChange} />
            </div>

            <div className="mt-5">
                <label className="h3 form-label">Phone</label>
                <input value={formData.Phone} name="Phone" type="text" className="form-control" onChange={handleChange} />
            </div>

            <button onClick={handleSubmit} className="btn btn-dark btn-lg w-100 mt-5">Submit</button>
            <button onClick={() => props.onPostCreated(null)} className="btn btn-secondary btn-lg w-100 mt-3">Cancel</button>
        </form>
    );
}
