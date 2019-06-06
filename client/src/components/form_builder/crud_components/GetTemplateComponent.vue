<template>
  <q-page>

    <H2>Get Saved Template</H2>

    <q-btn label="Refresh" color="primary" @click="this.onRefresh" class="q-mb-md" ></q-btn>

    <q-table
      :loading="loading"
      title="Alle Skabeloner"
      :data="data"
      :columns="columns"
      row-key="id"
    >
    <template v-slot:body="props">
      <q-tr :props="props" >

        <q-td key="id" :props="props">{{ props.row.id }}</q-td>

        <q-td key="name" :props="props">
          {{ props.row.name }}
          <q-icon
            class="cursor-pointer"
            name="edit"
          >
            <q-tooltip
            transition-show="scale"
            transition-hide="scale"
            >
              Rediger navnet på skabelonen.
            </q-tooltip>
          </q-icon>
          <q-popup-edit
            v-model="props.row.name"
            title="Update Name"
            buttons persistent
            label-set="Save"
            @save="updateRow(props.row)"
            >
            <q-input
              type="string"
              v-model="props.row.name"
              dense autofocus
              />
          </q-popup-edit>
        </q-td>

        <q-td key="headline" :props="props">
          <div class="text-pre-wrap">{{ props.row.headline }}
            <q-icon
              class="cursor-pointer"
              name="edit"
            >
              <q-tooltip
              transition-show="scale"
              transition-hide="scale"
              >
              Rediger overskriften på input feltet.
              </q-tooltip>
            </q-icon>
          </div>
          <q-popup-edit
            v-model="props.row.headline"
            title="Update Headline"
            buttons
            persistent
            label-set="Save"
            @save="updateRow(props.row)"
          >
            <q-input type="string" v-model="props.row.headline" dense autofocus />
          </q-popup-edit>
        </q-td>

        <q-td key="completedDate" :props="props">{{ props.row.completedDate }} </q-td>

        <q-td key="trash" :props="props">
          <q-icon
            v-model="props.row.id"
            name="delete"
            color="negative"
            class="cursor-pointer"
            @click="deleteRow(props.row.id)"
          >
            <q-tooltip
              transition-show="scale"
              transition-hide="scale"
            >
              Slet skabelonen.
            </q-tooltip>
          </q-icon>

        </q-td>
      </q-tr>
      </template>

    </q-table>

  </q-page>
</template>

<script>
import { mapGetters, mapActions } from 'vuex'

export default {

  data () {
    return {
      loading: true,
      selectedRow: [ ],
      data: this.getTableData,
      columns: [
        { name: 'id', label: 'Id', align: 'left', field: 'id', sortable: true, required: true },
        { name: 'name', label: 'Navn', align: 'left', field: 'name', sortable: true, required: true },
        { name: 'headline', label: 'Overskrift', align: 'left', field: 'headline', sortable: true },
        { name: 'completedDate', label: 'Sidst Redigeret', align: 'left', field: 'completedDate', sortable: true, required: true },
        { name: 'trash', align: 'left' }
      ]
    }
  },
  created () {
    this.onRefresh()
  },
  methods: {
    ...mapActions([
      'fetchFormsFromDb',
      'updateRow',
      'deleteRow'
    ]),
    onRefresh () {
      const fetchTableData = this.fetchFormsFromDb()

      Promise.all([fetchTableData])
        .then(() => {
          this.data = this.$store.getters.getTableData
          this.loading = false
        })
    }
  },
  computed: {
    ...mapGetters([
      'getTableData'
    ])
  }
}

</script>
