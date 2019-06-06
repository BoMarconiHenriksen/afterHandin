import { expect } from './jestGlobals'
import { getLayoutData, getTableData } from '../../../src/store/layouts/getters'

// Test getLayoutData
describe('getters', () => {
    test('getLayoutData, gets the grid layout from State.gridLayout.', () => {
        const gridLayout = [
            { 'x': 0, 'y': 0, 'w': 2, 'h': 2, 'i': 1, 'component': 'appInputFieldComponent', 'isComponent': true, 'content': '', 'static': false },
            { 'x': 1, 'y': 1, 'w': 4, 'h': 4, 'i': 2, 'component': 'appInputFieldComponent', 'isComponent': true, 'content': '', 'static': false }
        ]

        /* Create a fake state object */
        const state = {
            gridLayout: [
                { 'x': 0, 'y': 0, 'w': 2, 'h': 2, 'i': 1, 'component': 'appInputFieldComponent', 'isComponent': true, 'content': '', 'static': false },
                { 'x': 1, 'y': 1, 'w': 4, 'h': 4, 'i': 2, 'component': 'appInputFieldComponent', 'isComponent': true, 'content': '', 'static': false }
            ]
        }
        const result = getLayoutData(state)
        /* Test that objects have the same types as well as structure */
        expect(state.gridLayout).toStrictEqual(gridLayout)
        /* Compare recursively all properties of object instances */
        expect(result).toEqual(gridLayout)
        expect(result).toHaveLength(2)
    })
})

// Test getTableData
describe('mutations', () => {
    test('getTableData, get tableData from State.tableData.', () => {

        const tableData = [
            { id: 1, name: 'Brand', headline: 'Hvor brander det?', data: '29-11-1999' },
            { id: 2, name: 'Bil uheld', headline: 'Skal der bestilles fejeblad?', data: '19-01-1999' }
        ]

        /* Create a fake state object */
        const state = {
            tableData: [
                { id: 1, name: 'Brand', headline: 'Hvor brander det?', data: '29-11-1999' },
                { id: 2, name: 'Bil uheld', headline: 'Skal der bestilles fejeblad?', data: '19-01-1999' }
            ]
        }
        const result = getTableData(state)
        /* Compare recursively all properties of object instances */
        expect(result).toEqual(tableData)
        expect(result).toHaveLength(2)
    })
})
