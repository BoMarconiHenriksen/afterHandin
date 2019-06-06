import { expect } from './jestGlobals'
import { setNewGridItem, storeDeleteRow, storeUpdatRow, updateTableAfterPost } from '../../../src/store/layouts/mutations'

// Test setNewGridItem in mutation
describe('mutations', () => {
    test('setNewGridItem, sets a grid layout field to State.gridLayout.', () => {
        /* Create a gridlayout array that is added to the payload object */
        const gridLayout = [
            { 'x': 0, 'y': 0, 'w': 2, 'h': 2, 'i': 1, 'component': 'appInputFieldComponent', 'isComponent': true, 'content': '', 'static': false },
            { 'x': 1, 'y': 1, 'w': 4, 'h': 4, 'i': 2, 'component': 'appInputFieldComponent', 'isComponent': true, 'content': '', 'static': false }
        ]
        const inputFieldLayout = { 'x': 1, 'y': 1, 'w': 4, 'h': 4, 'i': 2, 'component': 'appInputFieldComponent', 'isComponent': true, 'content': '', 'static': false }
        /* Create a fake state object */
        const state = {
            gridLayout: [ { 'x': 0, 'y': 0, 'w': 2, 'h': 2, 'i': 1, 'component': 'appInputFieldComponent', 'isComponent': true, 'content': '', 'static': false } ]
        }
        setNewGridItem(state, inputFieldLayout)
        /* Test that objects have the same types as well as structure */
        expect(state.gridLayout).toStrictEqual(gridLayout)
        /* Compare recursively all properties of object instances */
        expect(state.gridLayout).toEqual(gridLayout)
        expect(state.gridLayout).toHaveLength(2)
    })
})

// Test delete tableData mutation
describe('mutations', () => {
    test('storeDeleteRow, delete a row in State.tableData.', () => {
        /* Create a gridlayout array that is added to the payload object */
        const id = 1

        /* Create a fake state object */
        const state = {
            tableData: [
                { id: 1, name: 'Brand', headline: 'Hvor brander det?', data: '29-11-1999' },
                { id: 2, name: 'Bil uheld', headline: 'Skal der bestilles fejeblad?', data: '19-01-1999' }
            ]
        }
        storeDeleteRow(state, id)
        /* Compare recursively all properties of object instances */
        expect(state.tableData).toHaveLength(1)
    })
})

// Test storeUpdatRow
// TODO: Make this test pass
describe('mutations', () => {
    test('storeUpdateRow, sets a grid layout field to State.gridLayout.', () => {

        const EditedRow = { completedDate: "2019-05-15T00:00:00", headline: "Indtast Dit Navn", id: 1, indexFromFetch: "0", name: "Brand og redning" }
        // Create a fake state object
        const state = {
            tableData: [{ completedDate: "2019-05-15T00:00:00", headline: "", id: 1, indexFromFetch: "0", name: "" }]
        }
        storeUpdateRow(state, EditedRow)

        expect(state.tableData[0].headline).toBe("Indtast Dit Navn")
        expect(state.tableData[0].name).toBe("Brand og redning")
    })
})

// Test that the store updates after a new post
describe('mutations', () => {
    test('updateTableAfterPost, updates the store after a new post.', () => {
        /* Create a gridlayout array that is added to the payload object */
        const template = { name: 'Name of the form', completedForms: [{ completedDate: "2019/05/05", formFieldValues: [{ value: '' }] }], formFields: [{ id: 0, column: null, component: { id: 0, componentName: 'A component name', formFieldId: 0 }, headline: 'A headline', height: null, row: null, static: false, width: null, formFieldValues: [] }] }

        /* Create a fake state object */
        const state = {
            tableData: [
                { id: 1, name: 'Brand', headline: 'Hvor brander det?', data: '29-11-1999' },

            ]
        }
        updateTableAfterPost(state, template)
        /* Compare recursively all properties of object instances */
        expect(state.tableData).toHaveLength(2)
    })
})
