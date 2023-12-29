<template>

    <!-- Header -->
  <main-header/>

    <!-- Content -->
    <article class="mt-[20px] content-padding">

        <!-- Listings Container -->
        <listings-container/>
        
    </article>
      
  <button class="mt-80" @click="appThemeService.toggleDarkMode()">Dark mode</button>

</template>
<script setup lang="ts">

import MainHeader from "@/common/components/MainHeader.vue";
import { AppThemeService } from "@/infrastructure/services/AppThemeService";
    import ListingsContainer from "@/modules/locations/components/ListingsContainer.vue";

const appThemeService = new AppThemeService();

</script>