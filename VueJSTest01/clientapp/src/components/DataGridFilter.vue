<template>

    <nav class="navbar navbar-expand-lg navbar-light bg-light justify-content-between">
        <div class="flex-grow-1"></div>
        <div class="flex-column">
            <div class="d-block position-relative">
                <div class="input-group mt-0 search-group" v-on:click="toggleSearch()">
                    <div class="input-group-prepend">
                        <span class="material-icons">
                            search
                        </span>
                    </div>
                    <div class="text-secondary text-elipsis">{{ generageSearchText }}</div>
                    <div class="cancel-button">
                        <button type="button" class="close" aria-label="Close" v-if="typeSearch!=0"
                                v-on:click.stop="changeTypeSearch(0)">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                </div>
                <div class="search-dropdown" v-if="showSearch">
                    <a href="#" v-on:click="changeTypeSearch(1)" v-if="typeSearch==0">
                        <span class="material-icons">
                            list_alt
                        </span> Sites
                    </a>
                    <a href="#" v-on:click="changeTypeSearch(2)" v-if="typeSearch==0">
                        <span class="material-icons">
                            list_alt
                        </span> Pages
                    </a>
                    <a href="#" v-on:click="changeTypeSearch(3)" v-if="typeSearch==0">Advanced Search</a>
                    <div class="advanced-form pt-3" v-if="typeSearch==3">
                        <div class="form-horizontal">
                            <div class="form-group d-flex">
                                <div class="col-4 label">Type</div>
                                <div class="col-8">
                                    <div class="dropdown">
                                        <a class="form-control dropdown-toggle" id="dropdownType"
                                           data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                            {{advancedSearch.typeName}}
                                        </a>
                                        <div class="dropdown-menu" aria-labelledby="dropdownType">
                                            <a class="dropdown-item" href="#"
                                               v-on:click="changeTypeAdvancedSearch(0, 'All types')">All types</a>
                                            <a class="dropdown-item" href="#"
                                               v-on:click="changeTypeAdvancedSearch(1, 'Sites')">Sites</a>
                                            <a class="dropdown-item" href="#"
                                               v-on:click="changeTypeAdvancedSearch(2, 'Pages')">Pages</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group d-flex">
                                <div class="col-4 label">Owner</div>
                                <div class="col-8">
                                    <div class="dropdown">
                                        <a class="form-control dropdown-toggle" id="dropdownOwner"
                                           data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                            {{advancedSearch.ownerTypeName}}
                                        </a>
                                        <div class="dropdown-menu" aria-labelledby="dropdownOwner">
                                            <a class="dropdown-item" href="#"
                                               v-on:click="changeOwnerSearch(0, 'Anyone')">Anyone</a>
                                            <a class="dropdown-item" href="#"
                                               v-on:click="changeOwnerSearch(1, 'Owned by me')">Owned by me</a>
                                            <a class="dropdown-item" href="#"
                                               v-on:click="changeOwnerSearch(2,'Not owned by me')">
                                                Not owned by
                                                me
                                            </a>
                                            <a class="dropdown-item" href="#"
                                               v-on:click="changeOwnerSearch(3, 'Specific person...')">
                                                Specific
                                                person...
                                            </a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group d-flex" v-if="advancedSearch.owner==3">
                                <div class="col-4 label">&nbsp;</div>
                                <div class="col-8">
                                    <div class="dropdown">
                                        <a class="form-control dropdown-toggle" id="dropdownOwner"
                                           data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                            {{advancedSearch.owner_search.name}}&nbsp;
                                        </a>
                                        <div class="dropdown-menu" aria-labelledby="dropdownOwner">
                                            <a class="dropdown-item" href="#"
                                               v-on:click="changeOwnerCustomSearch('sysadmin', 'admin@demo.com')">admin</a>
                                            <a class="dropdown-item" href="#"
                                               v-on:click="changeOwnerCustomSearch('designer', 'designer@demo.com')">designer</a>
                                            <a class="dropdown-item" href="#"
                                               v-on:click="changeOwnerCustomSearch('editor','editor@demo.com')">editor</a>
                                            <a class="dropdown-item" href="#"
                                               v-on:click="changeOwnerCustomSearch('sysadmin', 'sysadmin@demo.com')">sysadmin</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group d-flex">
                                <div class="col-4 label">&nbsp;</div>
                                <div class="col-8">
                                    <div class="row">
                                        <div class="col-6">
                                            <div class="custom-control custom-checkbox">
                                                <input type="checkbox" class="custom-control-input"
                                                       id="checkStarred" v-model="advancedSearch.is_starred">
                                                <label class="custom-control-label"
                                                       for="checkStarred">Starred</label>
                                            </div>
                                        </div>
                                        <div class="col-6">
                                            <div class="custom-control custom-checkbox">
                                                <input type="checkbox" class="custom-control-input"
                                                       id="checkInTrash" v-model="advancedSearch.is_trash">
                                                <label class="custom-control-label" for="checkInTrash">
                                                    In
                                                    Trash
                                                </label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group d-flex">
                                <div class="col-4 label">Date Modified</div>
                                <div class="col-8"></div>
                            </div>
                            <div class="form-group d-flex">
                                <div class="col-4 label">Modified Between</div>
                            </div>
                            <div class="col-8"></div>
                        </div>
                        <div class="form-group d-flex">
                            <div class="col-4 label">Item Name / Title</div>
                            <div class="col-8">
                                <input v-model="advancedSearch.item_name" class="form-control" type="text"
                                       placeholder="Enter a term that matches part of the field">
                            </div>
                        </div>
                        <div class="form-group d-flex">
                            <div class="col-4 label">Has the words</div>
                            <div class="col-8">
                                <input v-model="advancedSearch.words" class="form-control" type="text"
                                       placeholder="Enter words found in the item">
                            </div>
                        </div>
                        <div class="form-group d-flex">
                            <div class="flex-grow-1"></div>
                            <div>
                                <div class="col-12">
                                    <button type="button" class="btn btn-raised btn-default"
                                            v-on:click="resetAdvencedSearchForm()">
                                        Reset
                                    </button>
                                    <button type="button" class="btn btn-raised btn-success">Search</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="flex-grow-1">
        </div>
    </nav>

</template>

<script>
    export default {
        name: 'DataGridFilter',
        data() {
            return {
                showSearch: false,
                typeSearch: 0,
                advancedSearch: {
                    type: 0,
                    typeName: 'All types',
                    owner: 0,
                    ownerTypeName: 'Anyone',
                    owner_search: {
                        name: '',
                        email: ''
                    },
                    is_starred: false,
                    is_trash: false,
                    date_modified: 0,
                    modified_from: null,
                    modified_to: null,
                    item_name: '',
                    words: ''
                }
            }
        },
        computed: {
            generageSearchText() {
                var search_text = '';
                if (this.advancedSearch.type == 1) {
                    search_text += "type:site";
                }
                if (this.advancedSearch.type == 2) {
                    search_text += "type:page";
                }

                if (this.advancedSearch.owner == 1) {
                    search_text += " owner:me";
                }
                if (this.advancedSearch.owner == 2) {
                    search_text += " !owner:me";
                }
                if (this.advancedSearch.owner_search.email != '') {
                    search_text += " owner:" + this.advancedSearch.owner_search.email;
                }

                if (this.advancedSearch.is_starred) {
                    search_text += " is:starred";
                }

                if (this.advancedSearch.is_trash) {
                    search_text += " is:trash";
                }

                if (this.advancedSearch.words != '') {
                    search_text += ' ' + this.advancedSearch.words;
                }

                return search_text == '' ? 'Search' : search_text;
            }
        },
        methods: {
            toggleSearch: function () {
                this.showSearch = !this.showSearch;
            },
            changeTypeSearch: function (type) {
                this.typeSearch = type;
            },

            changeTypeAdvancedSearch: function (type, label) {
                this.advancedSearch.type = type;
                this.advancedSearch.typeName = label;
            },
            changeOwnerSearch: function (type, label) {
                this.advancedSearch.owner = type;
                this.advancedSearch.ownerTypeName = label;
            },
            changeOwnerCustomSearch: function (name, email) {
                this.advancedSearch.owner_search = {
                    name: name,
                    email: email
                };
            },
            resetAdvencedSearchForm: function () {
                this.advancedSearch = {
                    type: 0,
                    typeName: 'All types',
                    owner: 0,
                    ownerTypeName: 'Anyone',
                    owner_search: {
                        name: '',
                        email: ''
                    },
                    is_starred: false,
                    is_trash: false,
                    date_modified: 0,
                    modified_from: null,
                    modified_to: null,
                    item_name: '',
                    words: ''
                };
            }
        }
    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
    h3 {
        margin: 40px 0 0;
    }

    ul {
        list-style-type: none;
        padding: 0;
    }

    li {
        display: inline-block;
        margin: 0 10px;
    }

    a {
        color: #42b983;
    }

    .flex-grow-1 {
        flex-grow: 1;
    }

    .search-group {
        border: 1px solid #bbb;
        padding: 5px;
        box-shadow: 0 0 5px #ccc;
        ;
    }

    @media (min-width: 1200px) {
        .search-group {
            min-width: 450px;
        }
    }

    .search-dropdown {
        font-size: 0.9em;
        position: absolute;
        left: 0;
        width: 100%;
        background-color: #fff;
        background-clip: padding-box;
        border: 1px solid rgba(0, 0, 0, .15);
        border-radius: .125rem;
        box-shadow: 0 2px 2px 0 rgba(0, 0, 0, .14), 0 3px 1px -2px rgba(0, 0, 0, .2), 0 1px 5px 0 rgba(0, 0, 0, .12);
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
                background-color: rgba(0, 0, 0, .1);
            }

        .search-dropdown .bmd-form-group {
            padding-top: 0;
        }

        .search-dropdown .form-control.dropdown-toggle:after {
            float: right;
            margin-top: 5px;
        }

        .search-dropdown .dropdown-menu .dropdown-item {
            min-height: auto;
        }

        .search-dropdown .label {
            color: #aaa;
            padding-top: 5px;
        }

    .cancel-button {
        position: absolute;
        right: 13px;
        top: 5px;
    }
</style>
