<template>
  <div class="justify-content-between">
    <nav
      class="navbar navbar-expand-lg navbar-light bg-light justify-content-center"
    >
      <!-- Search box -->
      <div class="flex-column">
        <div class="d-block position-relative">
          <!-- Actual search box -->
          <div class="input-group mt-0 search-group" v-on:click="showSearch()">
            <div class="input-group-prepend">
              <span class="material-icons"> search </span>
            </div>
            <div class="text-secondary text-elipsis">
              {{ generageSearchText }}
            </div>
            <div class="cancel-button">
              <button
                type="button"
                class="close"
                aria-label="Close"
                v-if="typeSearch != 0"
                v-on:click.stop="changeTypeSearch(0)"
              >
                <span aria-hidden="true">&times;</span>
              </button>
            </div>

            <!--<span class="form-control-icon-remove" onclick="alert('ok');">
                                                <b-icon icon="x" aria-hidden="true"></b-icon>
                                            </span>-->
            <!-- Actual advanced search box -->

            <div class="search-dropdown" v-if="isSearchShow">
              <a
                href="#"
                v-if="typeSearch == 0"
                v-on:click="changeTypeSearch(1)"
              >
                <i class="material-icons">list_alt</i> Sites
              </a>
              <a
                href="#"
                v-if="typeSearch == 0"
                v-on:click="changeTypeSearch(2)"
              >
                <i class="material-icons">list_alt</i> Pages
              </a>
              <a
                href="#"
                v-if="typeSearch == 0"
                v-on:click="changeTypeSearch(3)"
                >Advanced Search</a
              >
              <!-- advanced-form -->
              <div class="advanced-form pt-3" v-if="typeSearch == 3">
                <div class="form-horizontal">
                  <div class="form-group d-flex">
                    <div class="col-4 label">Type</div>
                    <div class="col-8">
                      <!-- Type -->
                      <b-dropdown
                        :text="advancedSearch.typeName"
                        menu-class="w-100"
                        variant="primary"
                      >
                        <b-dropdown-item
                          href="#"
                          v-on:click="changeTypeAdvancedSearch(0, 'All types')"
                        >
                          All types
                        </b-dropdown-item>
                        <b-dropdown-item
                          href="#"
                          v-on:click="changeTypeAdvancedSearch(1, 'Sites')"
                        >
                          Sites
                        </b-dropdown-item>
                        <b-dropdown-item
                          href="#"
                          v-on:click="changeTypeAdvancedSearch(2, 'Pages')"
                        >
                          Pages
                        </b-dropdown-item>
                      </b-dropdown>
                    </div>
                  </div>
                  <div class="form-group d-flex">
                    <div class="col-4 label">Owner</div>
                    <div class="col-8">
                      <!-- typeOwner -->
                      <b-dropdown
                        :text="advancedSearch.typeOwnerName"
                        variant="primary"
                      >
                        <b-dropdown-item
                          href="#"
                          v-on:click="changeTypeOwnerSearch(0, 'All types')"
                        >
                          All types
                        </b-dropdown-item>
                        <b-dropdown-item
                          href="#"
                          v-on:click="changeTypeOwnerSearch(1, 'Owned by me')"
                        >
                          Owned by me
                        </b-dropdown-item>
                        <b-dropdown-item
                          href="#"
                          v-on:click="
                            changeTypeOwnerSearch(2, 'Not owned by me')
                          "
                        >
                          Not owned by me
                        </b-dropdown-item>
                        <b-dropdown-item
                          href="#"
                          v-on:click="
                            changeTypeOwnerSearch(3, 'Specific person...')
                          "
                        >
                          Specific person...
                        </b-dropdown-item>
                      </b-dropdown>
                    </div>
                  </div>
                  <div
                    class="form-group d-flex"
                    v-if="advancedSearch.typeOwnerSearch == 3"
                  >
                    <div class="col-4 label">Person</div>
                    <div class="col-8">
                      <!-- ownerSpecificPersonSearch -->
                      <b-dropdown
                        :text="advancedSearch.ownerSpecificPersonSearch.name"
                        variant="primary"
                      >
                        <b-dropdown-item
                          href="#"
                          v-on:click="
                            changeOwnerSpecificPersonSearch(
                              'admin',
                              'admin@demo.com'
                            )
                          "
                        >
                          admin
                        </b-dropdown-item>
                        <b-dropdown-item
                          href="#"
                          v-on:click="
                            changeOwnerSpecificPersonSearch(
                              'designer',
                              'designer@demo.com'
                            )
                          "
                        >
                          designer
                        </b-dropdown-item>
                        <b-dropdown-item
                          href="#"
                          v-on:click="
                            changeOwnerSpecificPersonSearch(
                              'editor',
                              'editor@demo.com'
                            )
                          "
                        >
                          editor
                        </b-dropdown-item>
                        <b-dropdown-item
                          href="#"
                          v-on:click="
                            changeOwnerSpecificPersonSearch(
                              'sysadmin',
                              'sysadmin@demo.com'
                            )
                          "
                        >
                          sysadmin
                        </b-dropdown-item>
                      </b-dropdown>
                    </div>
                  </div>
                </div>

                <div class="form-group d-flex">
                  <div class="col-4 label">&nbsp;</div>
                  <div class="col-8">
                    <div class="row">
                      <div class="col-6">
                        <div class="custom-control custom-checkbox">
                          <input
                            type="checkbox"
                            class="custom-control-input"
                            id="checkStarred"
                            v-model="advancedSearch.isStarred"
                          />
                          <label class="custom-control-label" for="checkStarred"
                            >Starred</label
                          >
                        </div>
                      </div>
                      <div class="col-6">
                        <div class="custom-control custom-checkbox">
                          <input
                            type="checkbox"
                            class="custom-control-input"
                            id="checkInTrash"
                            v-model="advancedSearch.isTrash"
                          />
                          <label
                            class="custom-control-label"
                            for="checkInTrash"
                          >
                            In Trash
                          </label>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>

                <div class="form-group d-flex">
                  <div class="col-4 label">Date Modified</div>
                  <div class="col-8">
                    <b-form-datepicker
                      menu-class="w-100"
                      v-model="advancedSearch.dateModified"
                      :date-format-optons="{
                        year: 'numeric',
                        month: 'numeric',
                        day: 'numeric',
                      }"
                    ></b-form-datepicker>
                  </div>
                </div>
                <div class="form-group d-flex">
                  <div class="col-4 label">Modified Between</div>
                  <div class="col-8">
                    <b-form-datepicker
                      menu-class="w-100"
                      v-model="advancedSearch.dateModifiedFrom"
                      :date-format-optons="{
                        year: 'numeric',
                        month: 'numeric',
                        day: 'numeric',
                      }"
                    ></b-form-datepicker>
                    <b-form-datepicker
                      menu-class="w-100"
                      v-model="advancedSearch.dateModifiedTo"
                      :date-format-optons="{
                        year: 'numeric',
                        month: 'numeric',
                        day: 'numeric',
                      }"
                    ></b-form-datepicker>
                  </div>
                </div>

                <div class="form-group d-flex">
                  <div class="col-4 label">Item Name / Title</div>
                  <div class="col-8">
                    <input
                      v-model="advancedSearch.itemName"
                      class="form-control"
                      type="text"
                      placeholder="Enter a term that matches part of the field"
                    />
                  </div>
                </div>

                <div class="form-group d-flex">
                  <div class="col-4 label">Has the words</div>
                  <div class="col-8">
                    <input
                      v-model="advancedSearch.words"
                      class="form-control"
                      type="text"
                      placeholder="Enter words found in the item"
                    />
                  </div>
                </div>

                <div class="form-group d-flex">
                  <div class="flex-grow-1"></div>
                  <div>
                    <div class="col-12">
                      <button
                        type="button"
                        class="btn btn-raised btn-default"
                        v-on:click="resetAdvancedSearchForm()"
                      >
                        Reset
                      </button>
                      <button type="button" class="btn btn-raised btn-success">
                        Search
                      </button>
                    </div>
                  </div>
                </div>
              </div>
              <!-- end advanced-form -->
            </div>
            <!-- end Actual advanced search box -->
          </div>
          <!-- end Actual advanced search box -->
        </div>
      </div>
    </nav>

    <!-- Datatable -->
    <div class="container">
      <h2>Data Table</h2>
      <p>The filtered table:</p>
      <table class="table table-bordered">
        <thead>
          <tr>
            <th></th>
            <th>Page Name</th>
            <th>Employees</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(row, index) in filteredRows" :key="`employee-${index}`">
            <td>
              <input type="checkbox" />
            </td>
            <td
              class="col-pagename"
              v-html="highlightMatches(row.pagename)"
            ></td>
            <td
              v-html="highlightMatches([...row.employees].sort().join(', '))"
            ></td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script>
import clickOutside from "../directives/snippet";

export default {
  name: "DataGridFilter",
  directives: {
    clickOutside: clickOutside,
  },
  data: function () {
    return {
      isSearchShow: false,
      filter: "",
      typeSearch: 0,
      advancedSearch: {
        typeSearch: 0,
        typeName: "All types",
        typeOwnerSearch: 0,
        typeOwnerName: "Anyone",
        ownerSpecificPersonSearch: {
          name: "Anyone",
          email: "",
        },
        isStarred: false,
        isTrash: false,
        dateModified: null,
        dateModifiedFrom: null,
        dateModifiedTo: null,
        itemName: "",
        words: "",
      },
      rows: [
        { pagename: "Accounting", employees: ["Bradley", "Jones", "Alvarado"] },
        {
          pagename: "Human Resources",
          employees: ["Juarez", "Banks", "Smith"],
        },
        { pagename: "Production", employees: ["Sweeney", "Bartlett", "Singh"] },
        {
          pagename: "Research and Development",
          employees: ["Lambert", "Williamson", "Smith"],
        },
        {
          pagename: "Sales and Marketing",
          employees: ["Prince", "Townsend", "Jones"],
        },
      ],
    };
  },
  methods: {
    hideSearch: function () {
      this.isSearchShow = false;
    },
    showSearch: function () {
      this.isSearchShow = true;
    },
    changeTypeSearch: function (type) {
      this.typeSearch = type;
    },
    changeTypeAdvancedSearch: function (type, typeName) {
      this.advancedSearch.typeSearch = type;
      this.advancedSearch.typeName = typeName;
    },
    changeTypeOwnerSearch: function (type, typeName) {
      this.advancedSearch.typeOwnerSearch = type;
      this.advancedSearch.typeOwnerName = typeName;
    },
    changeOwnerSpecificPersonSearch: function (name, email) {
      this.advancedSearch.ownerSpecificPersonSearch.name = name;
      this.advancedSearch.ownerSpecificPersonSearch.email = email;
    },
    changeDateModified: function (dateModified) {
      this.dateModified = dateModified;
    },
    resetAdvancedSearchForm: function () {
      this.advancedSearch = {
        typeSearch: 0,
        typeName: "All types",
        typeOwnerSearch: 0,
        typeOwnerName: "Anyone",
        ownerSpecificPersonSearch: {
          name: "Anyone",
          email: "",
        },
        isStarred: false,
        isTrash: false,
        dateModified: null,
        dateModifiedFrom: null,
        dateModifiedTo: null,
        itemName: "",
        words: "",
      };
    },
    highlightMatches: function (text) {
      const matchExists = text
        .toLowerCase()
        .includes(this.filter.toLowerCase());
      if (!matchExists) return text;

      const re = new RegExp(this.filter, "ig");
      return text.replace(
        re,
        (matchedText) => `<strong>${matchedText}</strong>`
      );
    },
  },
  events: {
    hideSearchEvent: function () {
      this.hideSearch();
    },
  },
  computed: {
    generageSearchText: function () {
      var search_text = "";
      if (this.advancedSearch.typeSearch == 1) {
        search_text += "type:site";
      }
      if (this.advancedSearch.typeSearch == 2) {
        search_text += "type:page";
      }

      if (this.advancedSearch.typeOwnerSearch == 1) {
        search_text += " owner:me";
      }
      if (this.advancedSearch.typeOwnerSearch == 2) {
        search_text += " !owner:me";
      }
      if (this.advancedSearch.ownerSpecificPersonSearch.email != "") {
        search_text +=
          " owner:" + this.advancedSearch.ownerSpecificPersonSearch.email;
      }

      if (this.advancedSearch.isStarred) {
        search_text += " is:starred";
      }

      if (this.advancedSearch.isTrash) {
        search_text += " is:trash";
      }

      if (this.advancedSearch.words != "") {
        search_text += " " + this.advancedSearch.words;
      }

      return search_text == "" ? "Search" : search_text;
    },
    filteredRows: function () {
      return this.rows.filter((row) => {
        const employees = row.employees.toString().toLowerCase();
        const department = row.pagename.toLowerCase();
        const searchTerm = this.filter.toLowerCase();

        return (
          department.includes(searchTerm) || employees.includes(searchTerm)
        );
      });
    },
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.flex-grow-1 {
  flex-grow: 1;
}

/* search-group */

.search-group {
  border: 1px solid #bbb;
  padding: 5px;
  box-shadow: 0 0 5px #ccc;
}

@media (min-width: 1200px) {
  .search-group {
    min-width: 450px;
  }
}

.search-dropdown {
  top: 34px;
  font-size: 0.9em;
  position: absolute;
  left: 0;
  width: 100%;
  background-color: #fff;
  background-clip: padding-box;
  border: 1px solid rgba(0, 0, 0, 0.15);
  border-radius: 0.125rem;
  box-shadow: 0 2px 2px 0 rgba(0, 0, 0, 0.14), 0 3px 1px -2px rgba(0, 0, 0, 0.2),
    0 1px 5px 0 rgba(0, 0, 0, 0.12);
}

.search-dropdown > a {
  display: flex;
  padding: 7px 10px;
  color: #555;
  text-decoration: none;
}

.search-dropdown > a .material-icons {
  margin-right: 10px;
}

.search-dropdown > a:hover {
  background-color: rgba(0, 0, 0, 0.1);
}

.search-dropdown .b-dropdown .dropdown-item {
  min-height: auto;
}

.search-dropdown .dropdown button.dropdown-toggle {
  width: 100%;
}

.search-dropdown .label {
  color: #000;
  text-align: left;
  padding-top: 5px;
}

.cancel-button {
  position: absolute;
  right: 13px;
  top: 5px;
}

/* Table */

.col-pagename {
  text-align: left;
}
</style>
