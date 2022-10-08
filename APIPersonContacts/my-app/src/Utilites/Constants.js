const API_BASE_URL_DEVELOPMENT = 'https://localhost:7168';
const API_BASE_URL_PRODUCTION = '';

const ENDPOINTS = {
    GET_ALL_CONTACTS: 'get-all-contacts',
    GET_CONTACT_BY_ID: 'get-contact-by-id',
    CREATE_CONTACT: 'create-contact',
    UPDATE_CONTACT: 'update-contact',
    DELETE_CONTACT_BY_ID: 'delete-contact-by-id'
};

const development = {
    API_URL_GET_ALL_CONTACTS: `${API_BASE_URL_DEVELOPMENT}/${ENDPOINTS.GET_ALL_CONTACTS}`,
    API_URL_GET_CONTACT_BY_ID: `${API_BASE_URL_DEVELOPMENT}/${ENDPOINTS.GET_CONTACT_BY_ID}`,
    API_URL_CREATE_CONTACT: `${API_BASE_URL_DEVELOPMENT}/${ENDPOINTS.CREATE_CONTACT}`,
    API_URL_UPDATE_CONTACT: `${API_BASE_URL_DEVELOPMENT}/${ENDPOINTS.UPDATE_CONTACT}`,
    API_URL_DELETE_CONTACT_BY_ID: `${API_BASE_URL_DEVELOPMENT}/${ENDPOINTS.DELETE_CONTACT_BY_ID}`
};

const production = {
    API_URL_GET_ALL_CONTACT: `${API_BASE_URL_PRODUCTION}/${ENDPOINTS.GET_ALL_CONTACTS}`,
    API_URL_GET_CONTACT_BY_ID: `${API_BASE_URL_PRODUCTION}/${ENDPOINTS.GET_CONTACT_BY_ID}`,
    API_URL_CREATE_CONTACT: `${API_BASE_URL_PRODUCTION}/${ENDPOINTS.CREATE_CONTACT}`,
    API_URL_UPDATE_CONTACT: `${API_BASE_URL_PRODUCTION}/${ENDPOINTS.UPDATE_CONTACT}`,
    API_URL_DELETE_CONTACT_BY_ID: `${API_BASE_URL_PRODUCTION}/${ENDPOINTS.DELETE_CONTACT_BY_ID}`
};

const Constants = process.env.NODE_ENV === 'development' ? development : production;

export default Constants;
