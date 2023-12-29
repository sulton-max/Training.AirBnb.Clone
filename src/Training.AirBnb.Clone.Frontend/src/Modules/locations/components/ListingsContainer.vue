<template>

    <div class="flex flex-col items-center justify-center theme-bg-primary">

        <!-- Listings category tab -->
        <listings-category-tab :listingCategories="listingCategories"
                               :selectedCategoryId="selectedCategoryId"
                               @onCategorySelected="onCategorySelected"/>

        <!-- Listings grid -->
        
    </div>

</template>

<script setup lang="ts">

import ListingsCategoryTab from "@/modules/locations/components/ListingsCategoryTab.vue";
import { AirBnbApiClient } from "@/infrastructure/apiClients/airBnbApiClient/brokers/AirBnbApiClient";
import { ListingCategory } from "@/modules/locations/models/ListingCategory";
import { ref, onBeforeMount } from "vue";

const airBnbApiClient = new AirBnbApiClient();

const selectedCategoryId = ref<string>("");
const listingCategories = ref<Array<ListingCategory>>([]);

onBeforeMount(async () => {
    await loadListingCategoriesAsync();
});

const onCategorySelected = (categoryId: string) => {
    selectedCategoryId.value = categoryId;
    
};
    
const loadListingCategoriesAsync = async () => {
    const response = await airBnbApiClient.listingCategories.getAsync();
    
    if (response.response) {
        listingCategories.value = response.response;
        
        if (response.response.length > 0) selectedCategoryId.value = response.response[0].id;
    }
};
    
</script>